    public class LogWriter
    {
    private readonly object _lock = new object;
    public void Log(string message)
    {
        lock(_lock)
        {
            //write message to log file
            string appName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + Path.DirectorySeparatorChar + appName + ".log", true);
            sw.WriteLine(string.Format("{0:u} {1}", DateTime.Now, message));
            sw.Flush();
            sw.Close();
        }
    }
