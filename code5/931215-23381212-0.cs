    using System.Security.Principal;
    using System.Diagnostics;
    using System.Threading;   // for ThreadStart delegate and Thread class
    using System;             // for Console class
    namespace RunMyprogram
    {
        static class Program
        {
            static void Main(string[] args)
            {
                    ThreadStart ts = new ThreadStart(ShowProgress);
                    Thread t = new Thread(ts);
                    t.Start();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"/myBatFile.bat";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                    t.Join();
            }
            static void ShowProgress()
            {
                // This function will only show user that the program is running, like aspnet_regiis -i shows increasing dots.
               Console.WriteLine(""); //move the cursor to next line
               Console.WriteLine("Launching the application, this may take up to 10 minutes..... Thanks for your patience.");
               // 10 minutes have 600 seconds, I will display 'one' dot every 2 seconds, hence the counter till 300
               for(int i = 0; i < 300; i++)
               {
                   Console.Write(". ");
                   Thread.Sleep(2000);
               }
            }
        }
    }
