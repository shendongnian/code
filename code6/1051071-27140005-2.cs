    List<float> listX = new List<float>(listVectors.Count);
    List<float> listY = new List<float>(listVectors.Count);
    List<float> listZ = new List<float>(listVectors.Count);
    foreach (var vec in listVectors) {
        listX.Add(vec.x);
        listY.Add(vec.y);
        listZ.Add(vec.z);
    }
