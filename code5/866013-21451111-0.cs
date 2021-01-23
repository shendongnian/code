     class Cat : Animal {}
     void DoSomething<T>(T animal) where T:Animal
     {
        IEnumerable<T> repeatGeneric = Enumerable.Repeat(animal, 3);
        var repeatGenericVar = Enumerable.Repeat(animal, 3);
     } 
     void DoSomething(Animal animal)
     {
        IEnumerable<Animal> repeat = Enumerable.Repeat(animal, 3);
        var repeatVar = Enumerable.Repeat(animal, 3);
     } 
