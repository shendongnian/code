    public class Main
    {
        public Main()
        {
            //In use
            DoCalculation calc = new DoCalculation();
            calc.StartCalculation(123, 188, ReceivedResults);
            //Cancel after 1sec
            Thread.Sleep(1000);
            calc.CancelProcess();
        }
        public void ReceivedResults(string result)
        {
            Console.WriteLine(result);
        }
    }
    public class DoCalculation
    {
		private System.Diagnostics.Process process = new System.Diagnostics.Process();
        private Action<string> callbackEvent;
	    public void StartCalculation(int var1, int var2, Action<string> CallbackMethod)
	    {
            callbackEvent = CallbackMethod;
		    string argument = "-v1 " + var1 + " -v2 " + var2;
            //this is going to run a separate process that you'll have to make and
            //you'll need to pass in the argument via command line args. 
            RunProcess("calcProc.exe", argument);
	    }
	    public void RunProcess(string FileName, string Arguments)
	    {
		    SecurityPermission SP = new SecurityPermission(SecurityPermissionFlag.Execution);
		    SP.Assert();
		    process.StartInfo.UseShellExecute = false;
		    process.StartInfo.RedirectStandardOutput = true;
		    process.StartInfo.RedirectStandardError = true;
		    process.StartInfo.CreateNoWindow = true;
		    process.StartInfo.FileName = FileName;
		    process.StartInfo.Arguments = Arguments;
		    process.StartInfo.WorkingDirectory = "";
            process.OutputDataReceived += ProcessCompleted;
		    process.Start();
	    }
        public void CancelProcess()
        {
            if (process != null)
                process.Kill();
        }
        private void ProcessCompleted(object sender, DataReceivedEventArgs e)
        {
            string result = e.Data;
            if (callbackEvent != null)
            {
                callbackEvent.Invoke(result);
            }
        }
    }
