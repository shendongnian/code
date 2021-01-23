    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { ID = 1, Name = "John", Address = new Address { ID = 1, City = "New Jersey" } };
            PersonDTO personDTO = person.ConvertToDTO();
            Console.WriteLine(personDTO.Name);
        }
    }
