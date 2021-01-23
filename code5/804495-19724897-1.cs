    class Person
    {
        public int Age;
        public static int operator +(Person p, Person p2)
        {
            return p.Age + p2.Age;
        }
    }
    class Agent : Person
    {
    }
    static void Main()
    {
        Person p = new Person { Age = 23 };
        Agent agent = new Agent { Age = 25 };
        int res = p + agent;//Result 48
        Console.WriteLine("Result is "+ res);
    }
