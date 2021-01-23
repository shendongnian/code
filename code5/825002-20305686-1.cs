    // Serialize
    bin.Serialize(stream, fileInfoArray.Length);
    for (int i = 0; i < fileInfoArray.Length; i++)
    {
        viewerData[i] = new ViewerData(fileInfoArray[i]);
        bin.Serialize(stream, viewerData[i]);
    }
    // Deserialize
    BinaryFormatter formatter = new BinaryFormatter();
    int length = (int)formatter.Deserialize(fs);
    for (int i = 0; i < length ; i++)
    {
        viewerData[i] = (ViewerData)bin.Deserialize(fs);        
    }   
