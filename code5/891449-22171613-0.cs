    public class Creature
        {
            protected string Name { get; private set; }
            protected int Numberlegs { get; set; }
    
            public Creature(string name, int numLegs)
            {
                this.Name = name;
                this.Numberlegs = numLegs;
            }
    
    
    
            protected void Walk()
            {
                Console.WriteLine("Walking, walking, walking ....In Creature Method");
            }
        }
