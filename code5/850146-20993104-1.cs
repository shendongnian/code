    public class CommandLine
    
    {
    
    public static void Main(string[] args)
    
    {
    Process p = new Process();
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "cmd.exe";
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        p.StartInfo = info;
        p.Start();
        using (StreamWriter sw = p.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
            {
                sw.WriteLine(string.Format("git config --global user.name {0}",args[0]));
                sw.WriteLine(string.Format("git config --global user.email {0}",args[1]));
                sw.WriteLine("call start-ssh-agent");
                sw.WriteLine(string.Format("ssh-add {0}",args[2]));  
                System.Threading.Thread.Sleep(10000);
                sw.WriteLine(Environment.NewLine);
                sw.WriteLine("git clone git@github.com:myrepo");
            }
        }
        Console.WriteLine("Done");
    }}
