     public void ReadFromFile(string in_filePath)
        {
            byte[] stlBytes;
    //Memory logpoint 1
            stlBytes = File.ReadAllBytes(in_filePath);
    //Memory logpoint 2
            byte[] header = stlBytes.SubArray(0, cConstants.BYTES_IN_HEADER);
            byte[] triangles = stlBytes.SubArray(cConstants.BYTES_IN_HEADER, stlBytes.Length - cConstants.BYTES_IN_HEADER);
            ReadHeader(header);
            ReadTriangles(triangles);
            stlBytes = null;
            System.GC.Collect();
    //Evaluate memory logpoints here
        }
