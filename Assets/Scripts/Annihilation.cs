using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annihilation : MonoBehaviour {

    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals;
    private int count = 0;
    private float perlin;
    private float perlinY;
    private float perlinX;
    private float perlinZ;
    private Vector3 sc;
    private Vector3 initSc;

	void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        normals = mesh.normals;

        perlinX = Random.Range(-10000f, 10000f);
        perlinY = Random.Range(-10000f, 10000f);
        perlinZ = Random.Range(-10000f, 10000f);

        initSc = this.transform.localScale;
    }
	
	void Update ()
    {
        /*for (int i = count; i < Mathf.Min(count+10000, vertices.Length); i++)
        {
            perlin = Mathf.PerlinNoise(Time.time, i * 10f) - .5f;
            vertices[i] = Vector3.Lerp(vertices[i], vertices[i] + normals[i] * Time.deltaTime * perlin*10f, Time.deltaTime*.1f);
        }

        count += 10000;
        if (count >= vertices.Length) count = 0;

        mesh.vertices = vertices;
        mesh.RecalculateBounds();*/

        sc.x = .5f*Mathf.PerlinNoise(perlinX, Time.time*.3f);
        sc.y = .5f*Mathf.PerlinNoise(perlinY, Time.time*.3f);
        sc.z = .5f*Mathf.PerlinNoise(perlinZ, Time.time*.3f);

        this.transform.localScale = initSc + sc;
    }
}