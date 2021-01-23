            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.WorkingDirectory = @"C:\";
                process.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
                // Redirects the standard input so that commands can be sent to the shell.
                process.StartInfo.RedirectStandardInput = true;
                // Runs the specified command and exits the shell immediately.
                //process.StartInfo.Arguments = @"/c ""dir""";
                process.OutputDataReceived += ProcessOutputDataHandler;
                process.ErrorDataReceived += ProcessErrorDataHandler;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                // Send a directory command and an exit command to the shell
                process.StandardInput.WriteLine(path + "\\CopyFolder\\hunpos-tag.exe " + path + "\\CopyFolder\\model.hunpos.mte5.defnpout <" + path + "\\CopyFolder\\rr >" + path + "\\CopyFolder\\zz");
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
            }
