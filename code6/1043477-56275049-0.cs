public static class ServersManager
{      
        public static string GetDiskSpace()
        {
            return string.Join(" ", "df").Bash();
        }
        private static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
}
The function GetDiskSpace returns a table of the following form:
**Filesystem   |  1K-blocks  |   Used  |  Available  | Use% | Mounted on**
/dev/sda4      |   497240864 |  31182380 | 466058484  |  7%  |    /
