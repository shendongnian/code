    class Animal
    {
    }
    class Dog : Animal
    {
        Animal obj = new Dog();  // Allowed
        Dog obj1 = new Animal(); // Not allowed
    }
