    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                
            Timer time = new Timer();
            time.Elapsed += new ElapsedEventHandler(action);
            time.Interval = 100;
            time.Enabled = true;
            time.Start();
            string line = Console.ReadLine(); // Get string from user
            if (line == "exit") // Check for exit condition
	        {
		        break;
	        }
        
        }
        Console.WriteLine("End of Program\n");
    }
    static void action(Object sender, ElapsedEventArgs args)
    {
        Console.WriteLine("haha\n");
    }
    }
