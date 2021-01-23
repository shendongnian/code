        public class TestRProcess
        {
            public StringBuilder output = new StringBuilder();
            public StringBuilder error = new StringBuilder();
    
            string script =
    @"getwd()
    a<-1:3
    b<-4:6
    data<-data.frame(a,b)
    str(data)
    q()
    ";
    
            public void Process()
            {
                ProcessStartInfo ProcessParameters = new ProcessStartInfo(@"C:\Program Files\R\R-3.1.1\bin\R.exe")
                {
                    Arguments = "--vanilla --slave",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
    
                int Max_Time = 10000;
    
    
                Process p = new Process();
                p.StartInfo = ProcessParameters;
    
                //Borrowed: http://stackoverflow.com/questions/139593/processstartinfo-hanging-on-waitforexit-why
                output = new StringBuilder();
                error = new StringBuilder();
    
                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                {
                    p.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e.Data);
                        }
                    };
                    p.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            error.AppendLine(e.Data);
                        }
                    };
    
                    p.Start();
    
                    p.StandardInput.WriteLine(script);
    
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
    
                    if (p.WaitForExit(Max_Time) &&
                        outputWaitHandle.WaitOne(Max_Time) &&
                        errorWaitHandle.WaitOne(Max_Time))
                    {
    
                    }
                    else
                    {
                        throw new Exception("Timed Out");
                    }
                }
            }
