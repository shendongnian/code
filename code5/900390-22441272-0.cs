         var process = new Process();
         var startinfo = new ProcessStartInfo(@"c:\users\Shashwat\Desktop\test.bat");
         startinfo.RedirectStandardOutput = true;
         startinfo.UseShellExecute = false;
         process.StartInfo = startinfo;
         process.OutputDataRecieved += DoSomething;
         process.Start();
         process.BeginOutputReadLine();
         process.WaitForExit();
         //Event Handler
         public void DoSomething(object sener, DataReceivedEventArgs args)
         {
               //Do something
         } 
