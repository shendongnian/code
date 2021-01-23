    var fileName = WebConfigurationManager.AppSettings["JsonFileLocation"];
    List<Students> studentsList = new List<Students>();
    
    using (var sr = new StreamReader(fileName))
    {
     var jsonStudentsText = sr.ReadAllText();
     studentsList = JsonConvert.DeserializeObject<List<Students>>(jsonStudentsText); 
    }
    
    studentsList.Add(new Students{name = name, grade = grade});
    
    using (var sw = new StreamWriter(fileName))
    {
     using (JsonWriter jw = new JsonTextWriter(sw))
     {
      jw.Formatting = Formatting.Indented;
      JsonSerializer serializer = new JsonSerializer();
      serializer.Serialize(jw, studentsList);
     }
    }
