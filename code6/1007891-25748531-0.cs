    using System;
    using System.Timers;
    
    public class Example
    {
       private static Timer aTimer;
       private static bool delayComplete = false;
    
       public static void Main()
       {
          // Create a timer with a two second interval.
          aTimer = new System.Timers.Timer(5000);
          // Hook up the Elapsed event for the timer. 
          aTimer.Elapsed += OnTimedEvent;
          aTimer.Enabled = true;
    
          while (!delayComplete)
          {
             System.Threading.Thread.Sleep(100);
          }
       }
    
       private static void OnTimedEvent(Object source, ElapsedEventArgs e)
       {
          Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
          delayComplete = true;
       }
    }
