    class Example1
    {
         // static. could be used by static methods and it is shared between all instances
         private static int counter = 0;
         
         // instance variable, exists with different indipendent storage for every instance
         private int v;
         public Example1()
         {
              // We can use the static variable because it is shared between all instances..
              counter = counter + 1;
         }
         public int SumValue(int x)
         {
             // Sum only for the first 10 instances of this class..
             // Yes weird, but it is just a contrived example
             if(Example1.counter < 10)
                 this.v = this.v + x:
             return this.v;
             
         }
         // Cannot use the this keyword neither the instance internal variables
         // Could use the static variables
         public static int GetCurrentInstanceCounter()
         {
             return counter;
         }
    }
    void Main()
    {
        Example1 a = new Example1();
        
        // a is an instance of class Example1 and could use the this keyword
        int result = a.sumValue(10);
        Console.WriteLine(result.ToString());
        // GetCurrentInstanceCounter is static, no instance required to call it, just the class name 
        int c = Example1.GetCurrentInstanceCounter();
        Console.WriteLine("Created " + c.ToString() + " instances of Example1");
    }
