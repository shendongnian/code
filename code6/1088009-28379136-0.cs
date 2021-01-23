    // Blah is a namespace
    namespace Blah
    {
        // blah is the class name
        public class blah
        {
            // x, y and z are member variables.
            int x, y = 2;   
            int z = 0;
            
            // SayHiis a public static method. Thus it dont requires the 'blah' object to call this method.
            public static void SayHi()
            {
                Console.WriteLine("Hi: " + y);
            }
            
            // counting is a public non static method. Thus it requires the 'blah' object to call this method.
            public void counting()
            {
                z = x * y;
            }
        }
    }
    // CallingMethod is the method where you want to call the counting method of class 'blah'
    public void CallingMethod()
    {
         // As said above, you need a object to call the 'counting' method.
         blah objBlah = new blah();
         // Now call the non static method using this object.
         objBlah.counting();
         // and here you can directly call the non-static method SayHi like,
         blah.SayHi();
    }
