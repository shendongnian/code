    string str = "Test";
    MemoryStream stream = new MemoryStream();
    BinaryWriter writer = new BinaryWriter(stream);
    writer.Write(str.Length);
    writer.Write(Encoding.Default.GetBytes(str));
