            public static bool ExtractArchive(string f) {
            string tempDir = Environment.ExpandEnvironmentVariables(Configuration.ConfigParam("TEMP_DIR"));
            if (zipToolPath == null) return false;
            // Let them know what we're doing.
            Console.WriteLine("Unpacking '" + System.IO.Path.GetFileName(f) + "' to temp directory.");
            LogFile.LogDebug("Unpacking '" + System.IO.Path.GetFileName(f) + "' to temp directory '" + tempDir + "'.",
                System.IO.Path.GetFileName(f));
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            if (pid == PlatformID.Win32NT || pid == PlatformID.Win32S || pid == PlatformID.Win32Windows || pid == PlatformID.WinCE) {
                p.StartInfo.FileName = "\"" + Path.Combine(zipToolPath, zipToolName) + "\"";
                p.StartInfo.Arguments = " e " + "-y -o" + tempDir + " \"" + f + "\"";
            } else {
                p.StartInfo.FileName = Path.Combine(zipToolPath, zipToolName);
                p.StartInfo.Arguments = " e " + "-y -o" + tempDir + " " + f;
            }
            try {
                p.Start();
            } catch (Exception e) {
                Console.WriteLine("Failed to extract the archive '" + f + "'.");
                LogFile.LogError("Exception occurred while attempting to list files in the archive.");
                LogFile.LogExceptionAndExit(e);
            }
            string o = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            string[] ls = o.Split('\n');
            for (int i = 0; i < ls.Count(); i++) {
                string l = ls[i].TrimEnd('\r');
                if (l.StartsWith("Error")) {
                    LogFile.LogError("7za: Error '" + ls[i + 1] + "'.", f);
                    Console.WriteLine("Failed to extract the archive '" + f + "'.");
                    return false;
                }
            }
            return true;
        }
