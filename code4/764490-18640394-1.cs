    string windowsVersion = Utilities.GetWindowsVersion(); 
    //...
    static class Utilities { // Just a sample of cmd.exe invocation
        public static string GetWindowsVersion() {
            using(Process versionTool = new Process()) {
                versionTool.StartInfo.FileName = "cmd.exe";
                versionTool.StartInfo.Arguments = "/c ver";
                versionTool.StartInfo.UseShellExecute = false;
                versionTool.StartInfo.RedirectStandardOutput = true;
                versionTool.Start();
                string output = versionTool.StandardOutput.ReadToEnd();
                versionTool.WaitForExit();
                return output.Trim();
            }
        }
    }
