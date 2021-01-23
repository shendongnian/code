    public class GrandFather
    {
        public virtual void WhoAreYou()
        {
            Console.WriteLine("I am a GrandFather");
        }
    }
    public class Father : GrandFather
    {
        public new void WhoAreYou()
        {
            Console.WriteLine("I am a Father");
        }
    }
    public class Child : Father
    {
        public new void WhoAreYou()
        {
            Console.WriteLine("I am a Child");            
        }
    }
