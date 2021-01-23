    List<MyObject> list = new List<MyObject>();
    Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
    while(stream.Position < stream.Length)
    {
         MyObject obj = (MyObject)formatter.Deserialize(stream);
         list.add(obj);
    }
