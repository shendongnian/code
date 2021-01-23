    delegate void Cry();
    ...
    cat = new Cat(); dog = new Dog();
    
    ...
    foreach(var animal in animals)
    {
        if (animal is Cat)
        {
            Cry = cat.meow;
        }
        else if (animal is Dog)
        {
            Cry = dog.bark;
        }
        else {...}
        
        if (animal.isInPain)
        {
            Cry();
        }
    }
