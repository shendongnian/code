    public String getSessionKey(String pid)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C C:\\handle.exe -a -p " + pid,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            p.Start();
            String str = (p.StandardOutput.ReadToEnd());
            String[] arr = str.Split('\n');
            foreach (String s in arr)
            {
                if (s.Contains("Owned"))
                {
                    return s.Substring(s.Length - 3, 1);
                }
            }
            return "";
        }
