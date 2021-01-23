    class Program
    {
        static Person John;
        static void Main()
        {
            Console.WriteLine("Persons who exist {0}", Person.Total);
            John = new Person("John");
            John.Born();
            John.Birthday();
            Person Jane = new Person("Jane");
            Jane.Born();
            Console.WriteLine("Persons who exist {0}", Person.Total);
            Console.WriteLine("John's Age {0}", John.Age);
            Console.WriteLine("Jane's Age {0}", Jane.Age);
            Console.ReadKey(true); //Pause program
        }
    }
    class Person
    {
        public static int Total { get; private set; }
        public static Person()
        {
            Total = 0;
        }
        public string Name {get; private set;}
        public int Age { get; private set; }
        public Person(string name)
        {
            Name = name;
            Age = 0;
        }
        public void Born()
        {
            Total++;
        }
        public void Birthday()
        {
            Age++;
        }
        public void Death()
        {
            Total--;
        }
    }
