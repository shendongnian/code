    public string [] getBlendShapeNames (GameObject obj)
    {
        SkinnedMeshRenderer head = obj.GetComponent<SkinnedMeshRenderer>();
        Mesh m = head.sharedMesh;
        string[] arr;
        arr = new string [m.blendShapeCount];
        for (int i= 0; i < m.blendShapeCount; i++)
        {
          string s = m.GetBlendShapeName(i);
          print("Blend Shape: " + i + " " + s);
          arr[i] = s;
        }
        return arr;
    }
