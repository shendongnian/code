    static Animal CreateAnimal(string name)
    {
        switch(name)
        {
            case "Rex": return new Dog(name); break;
            case "Mittens": return new Cat(name); break;
            //etc
        }
    }
