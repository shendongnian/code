         using (Process exeProcess = Process.Start(startInfo))
         {
            using(StreamWriter str = exeProcess.StandardInput)
            {
               str.WriteLine("ls");
               str.Flush();
               exeProcess.WaitForExit();
            }
         }
