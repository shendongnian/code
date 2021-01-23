    class Creature 
    {
        protected int Numberlegs { get; set; }
    }
    class Mammal : Creature
    {
        // new declaration of a property Numberlegs, coincidentally named 
        // the same as Numberlegs in the base class
        protected new int Numberlegs { get; set; } // notice the 'new' keyword
        void Method()
        {
            base.Numberlegs; // denotes Creature.Numberlegs
            this.Numberlegs; // denotes Mammal.Numberlegs
        }
    }
