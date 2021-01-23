    public class Person
    {
        string Name { get; set; }
    }
    
    public static class Validation
    {
        public static void ValidateName(this Person person)
        {
            if(person.Name.Contains("0", ..., "9"))
                throw new Exception("Name can't contain numbers.")
        }
    }
