    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Lec044b_ForLoop_Sum
    {
        class Program
        {
            public void Play()
            {
                Console.WriteLine("Announce Program");
                Console.WriteLine("Close Program Announcement");
                Timer t = new Timer(timerC, null, 5000, 5000);
            }
    
            private void timerC(object state)
            {
                Environment.Exit(0);
            }
    
            static void Main(string[] args)
            {
                Program myProgram = new Program();
                myProgram.Play();
                Console.ReadLine();
            }
        }
    }
