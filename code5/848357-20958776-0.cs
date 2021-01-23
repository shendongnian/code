            // File path.
            var lessCompilerPath = "...\\lessc.wsf";
            var lessPath = "site.less");
            var cssPath = "site.css");
            // Compile.
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("cscript")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    Arguments = "//nologo \"" + lessCompilerPath + "\" \"" + lessPath + "\" \"" + cssPath + "\" -filenames",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            process.WaitForExit();
            // Error.
            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException(process.StandardError.ReadToEnd());
            }
