    public class PersonObserver : IObserver<Person>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("Error occurred: " + error.ToString());
        }
        public void OnNext(Person person)
        {
            Console.WriteLine($"Received '{person.Firstname} {person.Lastname}'");
        }
    }
