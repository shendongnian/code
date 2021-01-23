    public class Person
    {
        [JsonProperty("name")]
        [JsonConverter(typeof(TrimmingConverter))] // <-- that's the important line
        public string Name { get; set; }
        [JsonProperty("other")]
        public string Other { get; set; }
    }
    var json = @"{ name:"" John "", other:"" blah blah blah "" }"
    var p = JsonConvert.DeserializeObject<Person>(json);
    Console.WriteLine("Name is: \"{0}\"", p.Name);
    Console.WriteLine("Other is: \"{0}\"", p.Other);
    //Name is: "John"
    //Other is: " blah blah blah "
