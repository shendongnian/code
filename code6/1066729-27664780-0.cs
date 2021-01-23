    [HttpPost]
    public ActionResult Publish()
    {
        try
        {
            string cmdResult = "";
            new Thread(new ParameterizedThreadStart(x =>
            {
                cmdResult = ExecuteCommand("casperjs test.js");
            })).Start();
            var response = Request.CreateResponse<string>(System.Net.HttpStatusCode.OK, cmdResult);
            return response;
        }
        catch (Exception e)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
        }
    }
    private string ExecuteCommand(string Command)
    {
        string result = "";
        try
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            Process process = Process.Start(processInfo);
            process.WaitForExit();
            while (!process.StandardOutput.EndOfStream)
            {
                result += process.StandardOutput.ReadLine();
            }
            while (!process.StandardError.EndOfStream)
            {
                result += process.StandardError.ReadLine();
            }
        }
        catch (Exception e)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(e.ToString()));
            throw;
        }
        return result;
    }
