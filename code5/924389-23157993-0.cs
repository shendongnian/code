    public class BaseClass
    {
        // Stuff common to Apples & Bananas here
        public abstract void DoStuff(Query query);
    }
    public class Apple : BaseClass
    {
        public int Diameter { get; set; }
        public override void DoSomething()
        {
            // . . .
        }
        public override DoStuff(Query query)
        {
            // Implementation for Apples
        }
    }
    public class Bananas : BaseClass
    {
        public int length { get; set; }
        public override void DoSomething()
        {
            // . . .
        }
        public override DoStuff(Query query)
        {
            // Implementation for Bananas
        }
    }
