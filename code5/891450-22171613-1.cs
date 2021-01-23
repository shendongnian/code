        public int Age { get; set; }
        public Mammal(string namen, int age)
            : base(namen, 4)
        {
            this.Age = age;
        }
        public void Sleep()
        {
            Console.WriteLine("Shhh! {0} is sleeping!", this.Name);
        }
        public void Walk()
        {
            Console.WriteLine(this.Name + " has started walking with " + this.Numberlegs + " legs");
            base.Walk();
        }
    }
