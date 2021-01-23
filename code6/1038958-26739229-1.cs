    public sealed class PersonClassMap : CsvClassMap<Person>
    {
        public PersonClassMap()
        {
            Map(m => m.Id).Index(0).Name("Id");
            Map(m => m.FirstName).Index(1).Name("First Name");
            Map(m => m.LastName).Index(2).Name("Last Name");
        }
    }
