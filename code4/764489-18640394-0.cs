    string version = GetVersionFromExternalConsoleTool(); 
    //...
    static string GetVersionFromExternalConsoleTool() {
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
