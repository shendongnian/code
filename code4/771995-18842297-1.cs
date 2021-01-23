    public class TEST : classB
    {
       public void test()
       {    
          Property1 = new classA();
          Property1.age = 24;
       }
       public static void Main()
       {
         TEST obj = new TEST();
         obj.test();
         Console.Read();
       }
    }
