    [JsonConverter(typeof(PersonListConverter))]
    class PersonList
    {
        public List<Person> Persons { get; set; }
    }
