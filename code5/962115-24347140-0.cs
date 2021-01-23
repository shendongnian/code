    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace StackOverFlowConsole3
    {
    
       public class NamedTimer : System.Timers.Timer
       {
          public readonly string name;
          
          public NamedTimer(string name)
          {
             this.name = name;
          }
       }
    
       class Program
       {
          static void Main()
          {
             for (int i = 1; i <= 10; i++)
             {
                var timer = new NamedTimer(i.ToString());
                timer.Interval = i * 1000;
                timer.Elapsed += Main_Tick;
                timer.AutoReset = false;
                timer.Start();
             }
             Thread.Sleep(11000);
          }
    
          static void Main_Tick(object sender, EventArgs args)
          {
             NamedTimer timer = sender as NamedTimer;
             Console.WriteLine(timer.name);
          }
       }
    }
