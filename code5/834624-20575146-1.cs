    public static class PersonService
    {
        public static List<Person> ReadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var data = from l in lines.Skip(1)
                       let split = l.Split(';')
                       select new Person
                       {
                           Id = int.Parse(split[0]),
                           Name = split[1],
                           Age = int.Parse(split[2]),
                           Gender = (Gender)Enum.Parse(typeof(Gender), split[3])
                       };
            return data.ToList();
        }
    }
