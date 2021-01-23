    p.Arguments = string.Format("{0} {1}", cmd, args);
         p.UseShellExecute = false;
         p.RedirectStandardOutput = true;
         using(Process process = Process.Start(p))
         {
             using(StreamReader reader = process.StandardOutput)
             {
                 string result = reader.ReadToEnd();
                 Console.Write(result);
             }
         }
