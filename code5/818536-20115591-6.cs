    public class Parent
    {
        public virtual void Print()
        {
            Console.WriteLine("Print in Parent");
        }
    }
    
    public class Child : Parent
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Print in Child");
        }
    }
