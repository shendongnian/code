        static void Main(string[] args)
        {
            var c = new C();
            c.Print();
            Console.ReadLine();
        }
        public abstract class A
        {
            public virtual void Print()
            {
                Console.WriteLine("I'm in A!");
            }
        }
        public abstract class B : A
        {
        }
        public class C : B
        {
            public override void Print()
            {
                Console.WriteLine("I'm in C!");
                base.Print();
            }
        }
