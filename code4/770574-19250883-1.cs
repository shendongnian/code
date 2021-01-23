    private string GetMethodName<T>(Expression<Action<T>> method)
    {
        return ((MethodCallExpression)method.Body).Method.Name;
    }
    public void TestMethod()
    {
        Person person = new Person();
        Console.WriteLine(GetMethodName<Person>(x => person.SayHello()));
        Console.WriteLine(GetMethodName<Person>(x => person.Greetings(1)));
        Console.ReadLine();
    }
    class Person
    {
        public void SayHello()
        {
            Console.WriteLine("Hello!");
        }
    
        public string Greetings(int numtimes)
        {
            for (int i = 0; i < numtimes; i++)
            {
                Console.WriteLine("Hello\n");
            }
            return "Finished";
        }
    }
