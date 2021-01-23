    string[] line = File.ReadAllLines("FilePath");
    if (null != line && line.Length > 0)
    {
        string[] values = line[0].Split(new char[',']);
        string variable1 = values[0]; //TEST DISK
        string variable2 = values[1]; //3819.9609375
    }
    
