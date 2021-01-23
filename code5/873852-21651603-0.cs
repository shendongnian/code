    var obj = JsonConvert.DeserializeObject<YourObject>(json);
---
    public class Hobby
    {
        public string Name { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
       
    public class YourObject
    {
        public string Success { get; set; }
        public Dictionary<string,Person>  Return { get; set; }
    }
