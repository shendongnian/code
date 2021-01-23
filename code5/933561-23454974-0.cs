    public class ClassB
    {
        private ClassA a;
        public ClassB(ClassA a)
        {
            this.a = a;
        }
    
        public int i { get { return a.i; } }
    
        void DoSomething()
        {
            Console.WriteLine(i);
        }
    }
