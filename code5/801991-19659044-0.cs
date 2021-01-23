    public partial class frmMain : Form
    {
        public static Process Process = new Process();
        public static bool ExecuteCommand(string sCommandLineFile, string sArguments)
        {
            Process.StartInfo.FileName = sCommandLineFile;
            Process.StartInfo.Arguments = sArguments;
            Process.StartInfo.CreateNoWindow = true;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process.Start();
            // Process.WaitForExit(); // Don't wait here, you want the application to be responsive
        }
    }
