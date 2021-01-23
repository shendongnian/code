    public static class PersonsManager
    {
        public static PersonStatistics LoadFromFile(string filePath)
        {
            var statistics = new PersonStatistics();
            using (var reader = new StreamReader(filePath))
            {
                var separators = new[] { ',' };
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue; //--malformed line
                    var lParts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (lParts.Length != 4)
                        continue; //--malformed line
                    var person = new Person
                    {
                        Age = int.Parse(lParts[0].Trim()),
                        Gender = lParts[1].Trim(),
                        MaritalStatus = lParts[2].Trim(),
                        District = int.Parse(lParts[3].Trim())
                    };
                    statistics.Persons.Add(person);
                }
            }
            return statistics;
        }
    }
    public class PersonStatistics
    {
        public List<Person> Persons { get; private set; }
        public PersonStatistics()
        {
            Persons = new List<Person>();
        }
        public IEnumerable<Person> GetAllByGender(string gender)
        {
            return GetByPredicate(p => string.Equals(p.Gender, gender, StringComparison.InvariantCultureIgnoreCase));
        }
        //--NOTE: add defined queries as many as you need
        public IEnumerable<Person> GetByPredicate(Predicate<Person> predicate)
        {
            return Persons.Where(p => predicate(p)).ToArray();
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int District { get; set; }
    }
