    class Test {
       static int count = 0;
       static void Main() {
          Console.WriteLine("In Main(), A.X=" + A.X);
       }
       public static int F(string message) {
           Console.WriteLine("Before " + message);
           return FInternal(message);
       }
    
       private static int FInternal(string message) {
          Console.WriteLine("Inside " + message);
          A.X = ++count;
    
          Console.WriteLine("\tA.X has been set to " + A.X);
          B.Y = ++count;
    
          Console.WriteLine("\tB.Y has been set to " + B.Y);
          return 999;
       }
    }
    class A {
       static A() { }
       public static int U = Test.F("Init A.U");
       public static int X = Test.F("Init A.X");
    }
    
    class B {
       static B() { }
       public static int R = Test.F("Init B.R");
       public static int Y = Test.F("Init B.Y");
    }
