    public class Program
    {
         public static readonly ResetEvent = new AutoResetEvent(true);
    
         public static void Main(string[] args) 
         {
              Task.Factory.StartNew
              (
                   () => 
                   {
                       // Imagine sleep is a long task which ends in 10 seconds
                       Thread.Sleep(10000);
    
                       // We release the whole AutoResetEvent
                       ResetEvent.Set();
                   }
              );
    
              // Once other thread sets the AutoResetEvent, the program ends
              ResetEvent.WaitOne();
         }
    }
