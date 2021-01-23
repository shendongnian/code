    dynamic dog = new ExpandoObject();
    dog.Name = "Rex";
    
    Action examineDog = delegate {
        Console.WriteLine("This is a dog. Its name is {0}.", dog.Name);
    };
    
    dog.Examine = examineDog;
    
    dynamic cat = new ExpandoObject();
    cat.Name = "Phil Collins";
    
    Action examineCat = delegate
    {
        Console.WriteLine("This is a cat. Its name is {0}.", cat.Name);
    };
    
    cat.Examine = examineCat;
    
    dog.Examine();
    cat.Examine();
