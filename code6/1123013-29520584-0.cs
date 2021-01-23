    string taskName = "This is a test";
    System.Diagnostics.Process process = new Process();
    process.StartInfo.Arguments = " /TN " + "\"" + taskName + "\"";
    
    Console.WriteLine(process.StartInfo.Arguments);
