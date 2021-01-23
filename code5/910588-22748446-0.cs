    public class A {
        public int x;
    }
    public struct B {
        public int x;
    }
    public static class Extension {
        public static A Add(this A value) {
            value.x += 1;
            return value;
        }
        public static B Add(this B value) {
            value.x += 1;
            return value;
        }
    }
    class Program {
        static void Main(string[] args) {
            A a = new A();
            B b = new B();
            Console.WriteLine("a=" + a.x);
            Console.WriteLine("b=" + b.x);
            a.Add();
            b.Add();
            Console.WriteLine("a=" + a.x); //a=1
            Console.WriteLine("b=" + b.x); //b=0
            Console.ReadLine();
        }
    }
