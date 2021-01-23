    class Program
    {
        static void Main()
        {
            int level ;
            //ask or determine which level wants to be played
            LaunchCommandLineApp(level);
        }
    
        /// <summary>
        /// Launch the legacy application with some options set.
        /// </summary>
        static void LaunchCommandLineApp(int level)
        {
        // For the example
        const string ex1 = "C:\\";
        const string ex2 = "C:\\Dir";
    
        // Use ProcessStartInfo class
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.CreateNoWindow = false;
        startInfo.UseShellExecute = false;
        startInfo.FileName = "Project" + level + ".exe";
        
        //I guess you dont need this
        //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;
    
        try
        {
            // Start the process with the info we specified.
            // Call WaitForExit and then the using statement will close.
            using (Process exeProcess = Process.Start(startInfo))
            {
            exeProcess.WaitForExit();
            }
        }
        catch
        {
            // Log error.
        }
        }
    }
