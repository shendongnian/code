    class CustomTriangle
    {
        private Vector3D normal;
        private Point3D vertex1, vertex2, vertex3;
    }
    private void loadMesh()
    {
        CustomTriangle triangle;
        MeshGeometry3D tempMesh = new MeshGeometry3D();
        HashSet<string> meshPositionsHashSet = new HashSet<string>();
        Dictionary<string, int> meshPositionsDict = new Dictionary<string, int>();
        int vertex1DuplicateIndex, vertex2DuplicateIndex, vertex3DuplicateIndex;
        int numberOfTriangles = GetNumberOfTriangles();
        for (int i = 0, j = 0; i < numberOfTriangles; i++)
        {
            triangle = ReadTriangleDataFromSTLFile();
            vertex1DuplicateIndex = -1;
            if (meshPositionsHashSet.Add(triangle.Vertex1.ToString()))
            {
                tempMesh.Positions.Add(triangle.Vertex1);
                meshPositionsDict.Add(triangle.Vertex1.ToString(), tempMesh.Positions.IndexOf(triangle.Vertex1));
                tempMesh.Normals.Add(triangle.Normal);
                tempMesh.TriangleIndices.Add(j++);
            }
            else
            {
                vertex1DuplicateIndex = meshPositionsDict[triangle.Vertex1.ToString()];
                tempMesh.TriangleIndices.Add(vertex1DuplicateIndex);
                tempMesh.Normals[vertex1DuplicateIndex] += triangle.Normal;
            }
            //Do the same for vertex2 and vertex3
        }
    }
