    using System;
    using System.Diagnostics;
    
    class HelloWorld
    {
        static void Main()
        {
            // lets say we want to run this command:    
            //  t=$(echo 'this is a test'); echo "$t" | grep -o 'is a'
            var output = ExecuteBashCommand("t=$(echo 'this is a test'); echo \"$t\" | grep -o 'is a'");
    
            // output the result
            Console.WriteLine(output);
        }
    
        static string ExecuteBashCommand(string command)
        {
            // according to: https://stackoverflow.com/a/15262019/637142
            // thans to this we will pass everything as one command
            command = command.Replace("\"","\"\"");
    
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \""+ command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
    
            proc.Start();
            proc.WaitForExit();
    
            return proc.StandardOutput.ReadToEnd();
        }
    }
