    public abstract class A
    {
        public virtual void CallMe() { Console.WriteLine("I am A."); }
    }
    public class B : A
    {
        public override void CallMe() { Console.WriteLine("I am B."); }
    }
