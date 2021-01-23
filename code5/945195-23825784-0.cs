    public class A
    {
        public virtual void WillBeInheritted()
        {
            
        }
        public virtual void WillBeOverridden()
        {
            
        }
        public virtual void WillBeHidden()
        {
            
        }
    }
    public class B : A
    {
        public override void WillBeOverridden()
        {
            
        }
        public virtual new void WillBeHidden()
        {
            
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            foreach(var meth in typeof(B).GetMethods())
            {
                Console.Write(meth.Name);
                Console.Write(": ");
                Console.Write(meth.GetBaseDefinition().DeclaringType.Name);
                Console.Write(" ");
                Console.WriteLine(meth.DeclaringType.Name);
            }
            Console.Read();
        }
    }
