    var l = new List<List<List<double>>>(
        Enumerable.Range(0, array3D.GetLength(0)).Select(i0 => new List<List<double>>(
            Enumerable.Range(0, array3D.GetLength(1)).Select(i1 => new List<double>(
                Enumerable.Range(0, array3D.GetLength(2)).Select(i2 => array3D[i0, i1, i2])
            ))
        )));
