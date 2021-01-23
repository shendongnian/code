    public class Enemy { }
    public class A : Enemy
    {
        public override string ToString()
        {
         	 return "A";
        }
    }
    public class B : Enemy
    {
        public override string ToString()
        {
            return "B";
        }
    }
    public class Stack { }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stack> d = new Dictionary<string, Stack>();
            A obj1 = new A();
            A obj2 = new A();
            B obj3 = new B();
            B obj4 = new B();
            d.Add(obj1.ToString(), new Stack());
            d.Add(obj2.ToString(), new Stack());
            d.Add(obj3.ToString(), new Stack());
            d.Add(obj4.ToString(), new Stack());
        }
    }
