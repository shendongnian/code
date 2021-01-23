    class Creature 
    {
        protected virtual int Numberlegs { get; set; }
    }
    class Mammal : Creature
    {
        protected override int Numberlegs { get; set; }
        void Method()
        {
            base.Numberlegs; // denotes Creature.Numberlegs
            this.Numberlegs; // denotes Mammal.Numberlegs
        }
    }
