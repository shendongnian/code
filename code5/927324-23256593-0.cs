    class ConversionQuestion
    {
        static void Main(string[] args)
        {
            Human human = ... // create an instance of Human, supply name and age
            Doggy doggy = ... // create an instance of Doggy, supply name and age
            Console.WriteLine("As a Human, {0} would be {1}", doggy.Name, DogToHumanConversion(doggy.Age));
            Console.WriteLine("As a Dog, {0} would be {1}", human.Name, HumanToDogConversion(human.Age));
            Console.ReadLine();
        }    
        private int DogToHumanConversion(int dogAge)
        {
            // convert dog age to human
    
            // return human age
        }
    
        private int HumanToDogConversion(int humanAge)
        {
            // convert human age to dog
    
            // return dog age
        }
    }
