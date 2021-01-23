    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string returnvalue;
    
                Process p = new Process();
    
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = ("D:\\adder.exe");
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.Start();
                Thread.Sleep(500);
                
                p.StandardInput.WriteLine("1");
                Thread.Sleep(500);
                p.StandardInput.WriteLine("2");
                Thread.Sleep(500);
                StreamReader sr = p.StandardOutput;
                returnvalue = sr.ReadToEnd();
    
                System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\AdderOutput.txt");
                file.WriteLine(returnvalue);
                file.Flush();
                file.Close();
            }
        }
    }
