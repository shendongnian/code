    using UnityEngine;
    using System.Collections;
    
    [RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
    public class ProceduralMeshScript : MonoBehaviour
    {
        //PUBLIC
        public int meshSize = 1;
        public float width = 1f;
        public float height = 1f;
        //PRIVATE
        private MeshFilter mF;
        private Mesh mesh;
        private Vector3[] verts;
        private Vector2[] vertsUV;
        private int[] triAs;
    
        // Use this for initialization
        void Start()
        {
            mF = GetComponent<MeshFilter>();
            mesh = new Mesh();
            mF.mesh = mesh;
            mesh.name = "CustomPlane";
    
            //Assign default material
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Diffuse"));
    
            //Create Mesh Resources
            CreateVerts();
            CreateTrias();
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        void CreateVerts()
        {
            //Set verts[] size = equal to the needed number of verts (2 times the x and y of how ever many squares there will be <meshSize>)
            verts = new Vector3[meshSize * 2 + meshSize * 2];
    
            //Keep track of current vert
            int curVert = 0;
    
            //Create Verts based on the specifed meshSize
            for (int x = 0; x < meshSize * 2; x++)
            {
                for (int z = 0; z < meshSize * 2; z++)
                {
                    float xf = width;
                    float zf = height;
                    verts[curVert] = new Vector3(xf * x, 0, zf * z);
                    curVert++;
                }
            }
            mesh.vertices = verts;
            for (int v = 0; v < verts.Length; v++)
            {
                Debug.Log("Vert " + v + ": " + verts[v].x + ", " + verts[v].z); 
            }
        }
    
        void CreateTrias()
        {
            //Set triAs[] to the total number of triangle points needed (6 times how ever many squares there will be <meshSize>)
            triAs = new int[meshSize * 6];
    
            //Keep track of seet points
            int triPoints = 0;
            int triFocus = 0;
    
            //Set every triangle point
            for (int t = 0; t < triAs.Length; t++)
            {
                switch (triPoints)
                {
                    case 0:
                        triAs[t] = triFocus + meshSize * 2;
                        triPoints++;
                        Debug.Log("case 0: " + triAs[t]);
                        break;
                    case 1:
                        triAs[t] = triFocus + 1;
                        triPoints++;
                        Debug.Log("case 1: " + triAs[t]);
                        break;
                    case 2:
                        triAs[t] = triFocus;
                        triPoints++;
                        Debug.Log("case 2: " + triAs[t]);
                        break;
                    case 3:
                        triAs[t] = triFocus + 1;
                        triPoints++;
                        Debug.Log("case 3: " + triAs[t]);
                        break;
                    case 4:
                        triAs[t] = triFocus + meshSize * 2;
                        triPoints++;
                        Debug.Log("case 4: " + triAs[t]);
                        break;
                    case 5:
                        triAs[t] = triFocus + meshSize * 2 + 1;
                        triPoints = 0;
                        triFocus += 2;
                        Debug.Log("case 5: " + triAs[t]);
                        break;
                    default:
                        triPoints = 0;
                        triFocus += 2;
                        break;
                }
            }
            mesh.triangles = triAs;
        }
    }
