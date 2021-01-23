    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stackoverflow1 {
    class Program {
        static void Main(string[] args) {
            var exe = "python";
            var arguments = "-i";
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo() {
                FileName = exe,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                CreateNoWindow = false,
            };
            p.OutputDataReceived += new DataReceivedEventHandler(
                delegate (object sendingProcess, DataReceivedEventArgs outLine) {
                    Console.WriteLine("{0}: {1}", exe, outLine.Data);
                    });
            p.ErrorDataReceived += new DataReceivedEventHandler(
                delegate (object sendingProcess, DataReceivedEventArgs errLine) {
                    Console.WriteLine("Error: " + errLine.Data);
                    });
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            StreamWriter sw = p.StandardInput;
            sw.AutoFlush = true; //does nothing
            if (exe == "cmd") {
                sw.WriteLine("echo hello");
                sw.WriteLine("echo 2+2");
                sw.WriteLine("echo Goodbye");
                }
            else { // assume python
                sw.WriteLine("print('Hello')");
                sw.WriteLine("2+2");
                sw.WriteLine("print('Printing from python')");
                sw.WriteLine("print('Goodbye')");
                }
            sw.Flush();
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("Closing");
            sw.Close();
            Console.ReadKey();
            }
       }
    }
