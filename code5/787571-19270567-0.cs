    binaryWriter.Write(sArray.Length); // BinaryWriter.Write(Int32) overload
    for (int i = 0; i < sArray.Length; i++)
    {
        binaryWriter.Write(sArray[i]); // BinaryWriter.Write(Int16) overload
    }
