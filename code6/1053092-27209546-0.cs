    interface IDog
    {
        void Bark();
        int NumberOfLegs {get;}
    }
    
    class Dog : IDog
    {
        public int NumberOfLegs {get {return 24;}}
        public void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }
