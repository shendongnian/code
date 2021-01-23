    public static void Deserialize()
    {
        var myDeserializer = new XmlSerializer(typeof(List<ToDo>));
        List<ToDo> ToDoList;
        using (var myFileStream = new FileStream("myXML.xml", FileMode.Open))
        {
            ToDoList = (List<ToDo>)myDeserializer.Deserialize(myFileStream);
        }
    }
