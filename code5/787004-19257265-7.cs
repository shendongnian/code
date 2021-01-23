    private static void Main(string[] args)
    {
        // Obtain parameter values from user
                
        Console.WriteLine("Enter a name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter a race");
        string race = Console.ReadLine();
        Console.WriteLine("Enter an age");
    
        // Console.ReadLine() reads values in as strings
        // Therefore you will need to convert the values you want as doubles
        double age;
        while (!double.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("The value you entered is not a valid age, please enter a valid age");
        }
        Console.WriteLine("Enter a weight");
        double weight;
        while (!double.TryParse(Console.ReadLine(), out weight))
        {
            Console.WriteLine("The value you entered is not a valid weight, please enter a valid weight");
        }
    
        // Create an instance of Animal
        Animal dog2 = new Animal(name, race, age, weight);
    }
