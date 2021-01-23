    public class Person
    {
       public int Id { get;set; }
       public string Name { get;set; }
    }
    // Then somewhere else
    string json = @"{ ""Id"": 10, ""Name"": ""Jeremy Vines"" }";
    JavaScriptSerializer JSS = new JavaScriptSerializer();
    Person obj = JSS.Deserialize<Person>(json);
    Console.WriteLine("Id: {0}, Name: {1}", obj.Id, obj.Name);
