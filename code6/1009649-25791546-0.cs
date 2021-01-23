    public class Animal
    {
        public string Name { get; private set; }
        public Animal(string name)
        {
            this.Name = name;
        }
        public void Examine()
        {
            Console.WriteLine("This is a {0}. Its name is {1}.", this.GetType(), Name);
        }
    }
    public void Dog : Animal
    {
        public Dog(string name) : base(name) { }
    }
    public void Cat : Animal
    {
        public Cat(string name) : base(name) { }
    }
