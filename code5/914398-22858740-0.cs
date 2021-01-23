    List<String> myList = new List<String>();
    ceva.Add("A");
    ceva.Add("B");
    ceva.Add("C!");
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    binaryFormatter.Serialize(writer.BaseStream, myList);
