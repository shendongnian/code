        public interface IBase
        {
          void Foo();
        }
        public class Derived1: IBase
        {
          public void Foo()
          {
            //Print Derived 1
          }
        }
        public class Derived2: IBase
        {
          public void Foo()
          {
            //Print Derived 2
          }
        }
       
       public class Program
       {
        public static void Main(String args[])
        {
          IBase base=new Derived1();
          base.Foo();//This prints Derived 1
          base=new Derived2();
          base.Foo();//This prints Derived 2
        }
       }
