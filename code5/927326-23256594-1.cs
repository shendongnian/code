    Human human = new Human( "Fred", 42 );
    Doggy dog = human;
    Console.WriteLine( "As a Human, {0} would be {1}", human.Name, human.Age );
    Console.WriteLine( "As a Dog, {0} would be {1}", dog.Name, dog.Age );
    Console.ReadLine();
