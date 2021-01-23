    class ConversionQuestion
    {
        static void Main(string[] args)
        {
            Doggy dog = new Doggy("Max", 3);
            Human human = new Human("Leonardo", 23);
            Console.WriteLine("As a Human, {0} would be {1}", DogToHuman(dog).Name, DogToHuman(dog).Age);
            Console.WriteLine("As a Dog, {0} would be {1}", HumanToDog(human).Name, HumanToDog(human).Age);
            Console.ReadLine();
        }
        public static Human DogToHuman(Doggy dog)
        {
            return new Human(dog.Name, (dog.Age * 7));
        }
        public static Doggy HumanToDog(Human human)
        {
            return new Doggy(human.Name, (human.Age / 7));
        }
    }
