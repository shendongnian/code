    class Program
    {
        static void Main(string[] args)
        {
            var extended = new DynamicExtension<IPerson>().Extend();
            extended.Person.Age = 25;
            extended.Name = "Billy";
            Console.WriteLine(extended.Name + " is " + extended.Person.Age);
             
            Console.Read();
        }
    }
