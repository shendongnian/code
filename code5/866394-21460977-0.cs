    static void Main()
    {
       ThreadTest tt = new ThreadTest();   // Create a common instance
       new Thread (tt.Go).Start();
       tt.Go();
    }
    
    public class ThreadTest
    {
        bool done;
        // Note that Go is now an instance method
        public void Go() 
        {
            if (!done) { done = true; Console.WriteLine ("Done"); }
        }
    }
