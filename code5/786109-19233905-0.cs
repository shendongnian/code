    public class Herple
    {
        public virtual void DoTheVirtualHerple()
        {
            Console.WriteLine("Virtual Herple!");
        }
    
        public void DoTheHerple()
        {
            Console.WriteLine("Herple!");
        }
    }
    
    public class Derple : Herple
    {
        public override void DoTheVirtualHerple()
        {
            Console.WriteLine("Actually I'd prefer to Derple!");
        }
    
        public new void DoTheHerple()
        {
            Console.WriteLine("Let's Derple instead!");
        }
    }
