    public class A<T>
    {
        public virtual void DoStuff(T value)
        {
            InternalDoStuff(value);
        }
        protected void InternalDoStuff(int value)
        {
            Console.WriteLine("Non-generic version");
        }
        protected void InternalDoStuff(T value)
        {
            Console.WriteLine("Generic version");
        }
    }
    public class B : A<int>
    {
        public override void DoStuff(int value)
        {
            InternalDoStuff(value);
        }
    }
