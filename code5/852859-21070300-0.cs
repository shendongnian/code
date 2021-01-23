        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = @"CMD.EXE";
            p.StartInfo.Arguments = @"/C bcdedit";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            // parse the output
            var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Where(l => l.Length > 24);
            foreach (var line in lines)
            {
                var key = line.Substring(0, 24).Replace(" ", string.Empty);
                var value = line.Substring(24).Replace(" ", string.Empty);
                Console.WriteLine(key + ":" + value);
            }
            Console.ReadLine();
        }
