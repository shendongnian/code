    class Bravo
    {
        public virtual void M() 
        {
            Console.WriteLine("Bravo!");
        }
        public Bravo()
        {
            M(); // Dangerous!
        }
    }
    class Delta : Bravo:
    {
        DateTime creation;
        public override void M() 
        {
            Console.WriteLine(creation);
        }
        public Delta() 
        {
            creation = DateTime.Now;
        }
    }
