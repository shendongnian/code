    try
    {
      Process process = new Process();
      process.StartInfo.FileName = "Recorder.exe";
      process.StartInfo.Arguments = "";
      process.Start();
    }
    catch(Exception e)
    {
       //Log using your logger the full error message.
    }
