     public interface Iface1
     {       
        int age { get; set; }
     }
     public class classA : Iface1
     {       
       public int age { get; set; }
     }
     public abstract class classB
     {       
        public classA Property1 { get; set; }
     }
     public class TEST : classB
     {
       public void test()
       {    
          if(Property1 == null)
          {
              Property1 = new classA();
          }
          Property1.age = 24;
       }
       public static void Main()
       {
         TEST obj = new TEST();
         obj.test();
         Console.Read();
       }
     }
