    class MyFileContents {
     public byte[] Part0;
     public byte[] Part1;
    }
    
    new BinaryFormatter().Serialize(myStream, new MyFileContents(...));
