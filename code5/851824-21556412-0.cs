    using System;
    using System.Diagnostics;
    
    public class VerifyJar
    {
        public static void Main()
        {
            Process p = new Process();
            p.StartInfo.FileName = "jarsigner"; // put in full path
            p.StartInfo.Arguments = "-verify liblinear-1.92.jar"; // put in your jar file
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
    
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
    
            // Handle the output with a string check probably yourself
            // Here I just display what the result for debugging purposes
            Console.WriteLine("Output:");
            Console.WriteLine(output);
    
            // For me, the output is "jar is unsigned. (signature missing or not parsable)"
            // which is correct for this particular jar file.
        }
    }
