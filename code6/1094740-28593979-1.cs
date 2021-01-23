    abstract class A_base {}
    abstract class A_derived : A_base {}
 
    abstract class B_base {
       public virtual T Foo<T>() where T : A_base, new() {
          Console.Write("1");
          return new T();
       }
    }
    abstract class B_derived : B_base {
       public new virtual T Foo<T>() where T : A_derived, new() {
          Console.Write("2");
          return base.Foo<T>();
       }
    }
 
    class C1 : A_base {}
    class C2 : A_derived {}
 
    class D1 : B_base {
       public override T Foo<T>() {
          Console.Write("3");
          return base.Foo<T>();
       }
       //override T Foo<T>() where T : A_derived, new() {
       //    //Error constraint mismatch
       //}
    }
    class D2 : B_derived {
       public override T Foo<T>()  {
          Console.Write("4");
          return base.Foo<T>();
       }
       //override T Foo<T>() where T : A_base, new() {
       //    //Error constraint mismatch
       //}
    }
    public class Program
    {
       public static int Main(string[] args) {
          //Comments are what is printed out.
          var d1 = new D1();
          var d2 = new D2();
          d1.Foo<C1>(); //31
          Console.WriteLine ();
          d1.Foo<C2>(); //31
          Console.WriteLine ();
          //d2.Foo<C1>(); //Error constraint mismatch
          d2.Foo<C2>(); //421
          Console.WriteLine ();
          B_base b_d2 = d2;
 	 	  b_d2.Foo<C1>(); //1
 		  Console.WriteLine();
		  b_d2.Foo<C2>(); //1
          Console.WriteLine ();
          return 0;
       }
    } 
