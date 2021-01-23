    public class PersonFromThatApi
    {
        [JsonProperty("pname")]
        public string Name { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
    }
    Mapper.CreateMap<PersonFromThatApi, Person>();
    Mapper.CreateMap<Person, PersonFromThatApi>();
    
    var person1 = JsonConvert.DeserializeObject<PersonFromThatApi>(
                                   @"{""pname"":""George""}");
    Person person2 = Mapper.Map<Person>(person1);
    string s = JsonConvert.SerializeObject(person2); // {"Name":"George"}
