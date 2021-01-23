    public static void Main()
    {
        // I am building something like an ASP.NET MVC ViewBag…
        // Though, there are myriad reasons why you should prefer
        // typed views ;-).
        dynamic bag = new ExpandoObject();
        bag.Name = "Joe";
        bag.RandomThing = "Ridiculousness.";
        DoSomething(bag);
    }
    
    static void DoSomething(dynamic bag)
    {
        Console.WriteLine("Hi, {0}.", bag.Name);
    }
