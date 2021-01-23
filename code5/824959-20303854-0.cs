    static void Main(string[] args)
    {
        dynamic p = person();
        Console.WriteLine("Name: {0}, Age: {1}, Is married: {2}", p.name, p.age, p.isMarried);
    }
    static dynamic person()
    {
        return new { name = "John Doe", age = 20, isMarried = false };
    }
