    List<Person> people = new List<Person>();
            people.Add(new Person() { LastName = "A" });
            people.Add(new Person() { LastName = "B" });
            people.Add(new Person() { LastName = "C" });
            var lastNames = (from person in people
                             select person.LastName);
            var result = string.Join(",", lastNames);
            Console.WriteLine(result);
