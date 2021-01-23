    class Dog
    {
        private readonly string name;
    
        public Dog(string name)
        {
            this.name = name;
        }
    
        public void Bark()
        {
            Console.WriteLine("{0} just barked!", name);
        }
    }
