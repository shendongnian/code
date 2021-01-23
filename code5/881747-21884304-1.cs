    MemberInfo m1 = typeof(Base).GetMethod("Method");
    MemberInfo m2 = typeof(Derived).GetMethod("Method");
    Console.WriteLine(m1.DeclaringType); //Base
    Console.WriteLine(m1.ReflectedType); //Base
    Console.WriteLine(m2.DeclaringType); //Base
    Console.WriteLine(m2.ReflectedType); //Derived
    public  class Base
    {
        public void Method() {}
    }
    public class Derived : Base { }
