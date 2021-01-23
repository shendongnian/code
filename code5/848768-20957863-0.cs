    JsonConvert.DeserializeObject<Root>(peopleJson);
    public class Root
    {
        public List<Person> items { get; set; }
    }
