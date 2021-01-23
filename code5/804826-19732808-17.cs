    class Program
    {
        static void Main(string[] args)
        {
            var extended = new DynamicExtension<Person>().ExtendWith<IPerson>();
            extended.Age = 25;
            extended.Name = "Billy";
            Console.WriteLine(extended.Name + " is " + extended.Age);
            Console.Read();
        }
    }
