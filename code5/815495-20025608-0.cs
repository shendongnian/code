    var list = new List<User>() {
        new User { FirstName = "user1", LastName = "user1" },
        new Employee { FirstName = "employee1", LastName = "employee1", JobTitle = "employee1" },
        new Manager() { FirstName = "manager1", LastName = "manager1", Department = "manager1"}
    };
    var serializer = new DataContractJsonSerializer(typeof(List<User>), new [] { typeof(Employee), typeof(Manager) });
    string json;
    using (var stream = new MemoryStream())
    {
        serializer.WriteObject(stream, list);
        stream.Position = 0;
        using(var reader = new StreamReader(stream))
        {
            json = reader.ReadToEnd();
        }
    }
    List<User> list2;
    using(var stream = new MemoryStream())
    {
        using(var writer = new StreamWriter(stream))
        {
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;
            list2 = (List<User>)serializer.ReadObject(stream);
        }
    }
