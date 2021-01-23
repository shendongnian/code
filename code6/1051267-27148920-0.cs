    Person person = new Person();
    person.fName = name.Text;
    person.id = int.Parse(id.Text);
    
    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Project\\";
    
    using (StreamReader r = new StreamReader(path + "persons.json")) {
        string json = r.ReadToEnd();
        List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(json);
        persons.Add(person);
        string newJson = JsonConvert.SerializeObject(persons); 
    } 
    
    File.WriteAllText(path + "persons.json", newJson);
