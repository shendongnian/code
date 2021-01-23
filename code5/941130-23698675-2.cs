    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = {
                new Sheep(),
                new Cow(),
                new Sheep(),
                new Cow(),
                new Cow()
            };
            foreach (Animal animal in animals)
            {
                animal.makeChild();
            }
        }
    }
