    public class PersonService
    {
        public PersonDto GetPersonById(int id)
        {
             Person person = dbContext.Persons.First();
             
             // Mapping in action.
             var personDto = new PersonDto()
             {
                 FirstName = person.FirstName,
                 LastName = person.LastName,
             };
             return personDto;
        }
    }
