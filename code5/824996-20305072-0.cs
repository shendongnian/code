    public static void Deserialize()
    {
        XmlSerializer myDeserializer = new XmlSerializer(ToDoList.GetType());
        FileStream myFileStream = new FileStream("myXML.xml", FileMode.Open);
        var listOfTodos = myDeserializer.Deserialize(myFileStream);
        myFileStream.Close();
    }
