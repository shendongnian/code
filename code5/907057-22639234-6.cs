        static void Main(string[] args)
        {            
            Stopwatch spw = new Stopwatch();
            spw.Start();
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = "driverquery.exe";
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.EnableRaisingEvents = true;
            pProcess.OutputDataReceived += outputRedirection;
            pProcess.Start();
            pProcess.BeginOutputReadLine();
            pProcess.WaitForExit();        
            pProcess.Close();
            spw.Stop();
            Console.WriteLine();
            Console.WriteLine("Completed in : " + 
                               spw.ElapsedMilliseconds.ToString() 
                               + "ms");
        }
