    interface ICry
    {
        string Cry { get; }
    }
    class Cat : ICry
    {
        public string Cry { get { return "Meow!"; } }
    }
    class Dog: ICry
    {
        public string Cry { get { return "Woof"; } }
    }
    class PetOwner
    {
        private Cat cat = new Cat();
        public ICry ICry {get{return cat;}}
    }
