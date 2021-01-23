    Animal[] reptiles = new Reptile[] 
        { new Reptile("lizard"), new Reptile("snake") };
    object[] animals = new object[]
        { new Reptile("alligator"), new Mammal("dolphin") };
    try
    {
        Array.ConstrainedCopy(animals, 0, reptiles, 0, 2);
    }
    catch (ArrayTypeMismatchException atme)
    {
        //Console.WriteLine('[' + String.Join<Animal>(", ", reptiles) + ']');
    }
