    List<Students> studentlist = JsonConvert.DeserializeObject<List<Students>>(your json);
    studentlist.Add(new Students{name = name, grade = grade});
    
    JsonSerializer serializer = new JsonSerializer();
    using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        serializer.Serialize(writer, studentlist);
        
    }
