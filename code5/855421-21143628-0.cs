       public static string ProcessStarter(string processName, string argString, string workingDirectory = null)
        {
            var prs = new Process();
            if (!string.IsNullOrWhiteSpace(workingDirectory))
            {
                prs.StartInfo.WorkingDirectory = workingDirectory;
            }
            prs.StartInfo.UseShellExecute = false;
            prs.StartInfo.RedirectStandardOutput = true;
            prs.StartInfo.RedirectStandardError = true;
            prs.StartInfo.FileName = processName;
            prs.StartInfo.Arguments = argString;
            // LOOK HERE
            prs.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; 
            prs.Start();
            string result = prs.StandardOutput.ReadToEnd();
            string resultErr = prs.StandardError.ReadToEnd();
            return string.IsNullOrEmpty(result) ? resultErr : result;
    }
