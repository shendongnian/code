    static void Main(string[] args)
        {
            Console.Write("How many persons you want to add?: ");
            int p = int.Parse(Console.ReadLine());
            var newPersons = CreatePersons(p);
             foreach (var person in newPersons)
             {
                 Console.WriteLine("Eneter age for Person :" person.Name);
                 person.Age = Console.ReadLine();
             }
        }
        static IEnumerable<Person> CreatePersons(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Person{ Name="newPerson" +1 };
            }
        } 
