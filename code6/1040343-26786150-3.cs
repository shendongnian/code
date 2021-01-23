    class Program
    {
        public class ParentClass
        {
            public virtual void foo()
            {
                Console.WriteLine("parent.foo");
            }
            public virtual void bar()
            {
                Console.WriteLine("parent.bar");
            }
        }
        public class InheritedClass : ParentClass
        {
            public new void foo()
            {
                Console.WriteLine("inherited.foo");
            }
            public override void bar()
            {
                Console.WriteLine("inherited.bar");
            }
        }
        static void Main(string[] args)
        {
            var inherited = new InheritedClass();
            var parent = inherited as ParentClass;
            var d = parent as dynamic;
            parent.foo();
            inherited.foo();
            d.foo();
            parent.bar();
            inherited.bar();
            d.bar();
            Console.Read();
        }
    }
