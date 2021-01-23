    public class Program
    {
        static void Main(string[] args)
        {
            Logic lol = new Logic();
            CreatePersonDto dto = new CreatePersonDto { FirstName = "Joe", Surname = "Bloggs" };
            var newPersonId = lol.Create(dto);
            foreach (var item in lol.ListOfPersons())
            {
                Console.WriteLine(item.Name);
            }
            //or to narrow down list of people
            QueryPersonDto queryDto = new QueryPersonDto { Surname = "Bloggs" }
            foreach (var item in lol.ListOfPersons(queryDto))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
