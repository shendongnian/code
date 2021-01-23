    public abstract class A { }
    public class B : A { 
        public int b { get; set; }
        public override string ToString()
        {
            return b.ToString();
        }
    }
    // Do the same with C and D ....
    A[] array = new A[] { new B(), new C(), new D() };
    foreach (A a in array) {
        Console.WriteLine(a);
    }
  
