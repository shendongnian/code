    using System;
    using System.Diagnostics;
    using System.IO;
    
    public class Stream_Read_Write
    {
        public static void Main()
        {
            string path = "C:\\Users\\thomas_wortmann\\Documents\\Python_Scripts\\io_test.py";
            string iter = "3";
            string input = "Hello";
    
            stream_read_write(path, iter, input);
    
            //Keep Console Open for Debug
            Console.Write("end");
            Console.ReadKey();
        }
    
        private static void stream_read_write(string path, string iter, string input)
        {
            ProcessStartInfo start = new ProcessStartInfo();
    
            start.FileName = "C:\\Python27\\python.exe";
            start.Arguments = string.Format("{0} {1}", path, iter);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;
            start.CreateNoWindow = true;
    
            using (Process process = Process.Start(start))
            using (StreamWriter writer = process.StandardInput)
            using (StreamReader reader = process.StandardOutput)
            {
                for (int i = 0; i < Convert.ToInt32(iter); i++)
                {
                    writer.WriteLine(input + i);
                    Console.WriteLine("written: " + input + i);
    
                    string result = null;
    
                    while (result == null || result.Length == 0)
                    { result = reader.ReadLine(); }
    
                    Console.WriteLine("read: " + result + "\n");
                }
            }
        }
    }
    
