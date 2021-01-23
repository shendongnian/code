    Dog dog = new Dog { Name = "Rex" };
    dog.Examine = delegate
    {
        Console.WriteLine("This is a dog. Its name is {0}.", dog.Name);
    };
    Cat cat = new Cat { Name = "Phil Collins" };
    cat.Examine = delegate
    {
        Console.WriteLine("This is a cat. Its name is {0}.", cat.Name);
    };
    dog.Examine();
    cat.Examine();
