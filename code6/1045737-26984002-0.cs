    LineRenderer lineRenderer = ... ; // Add or get LineRenderer component to game object
    lineRenderer.SetVertexCount(7);  // 6+1 since vertex 6 has to connect to vertex 1
    for (int i = 0; i < 7; i++) {
        Vector3 pos = ... ; // Positions of hex vertices
        lineRenderer.SetPosition(i, pos);
    }
