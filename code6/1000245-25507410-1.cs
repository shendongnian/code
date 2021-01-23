    public class A 
    {
         public virtual string Path
         {
             get { return "A"; }
         }
    }
    
    public class B : A 
    {
         public override string Path
         { 
             get { return base.Path + ".B"; }
         }
    }
    
    public class C : B 
    {
         public override string Path
         { 
             get { return base.Path + ".C"; }
         }
    }
    A a = new A();
    Console.WriteLine(a.Path); // Prints "A"
    
    B b = new B();
    Console.WriteLine(b.Path); // Prints "A.B"
    
    C c = new C();
    Console.WriteLine(c.Path); // Prints "A.B.C"
