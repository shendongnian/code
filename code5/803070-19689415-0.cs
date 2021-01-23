    /// <summary>
    /// Represents the entry point of our application.
    /// </summary>
    /// <param name="args">Possibly spcified command line arguments.</param>
    public static void Main(string[] args)
    {
        string batchCommands = string.Empty;
        string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///",string.Empty).Replace("/","\\");
        batchCommands += "@ECHO OFF\n";                         // Do not show any output
        batchCommands += "ping 127.0.0.1 > nul\n";              // Wait approximately 4 seconds (so that the process is already terminated)
        batchCommands += "echo j | del /F ";                    // Delete the executeable
        batchCommands += exeFileName + "\n";
        batchCommands += "echo j | del deleteMyProgram.bat";    // Delete this bat file
        File.WriteAllText("deleteMyProgram.bat", batchCommands);
        Process.Start("deleteMyProgram.bat");
    }
