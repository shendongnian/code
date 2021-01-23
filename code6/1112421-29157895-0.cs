            public static int Run(Action<string> output, string exe, string args)
            {
                if (String.IsNullOrEmpty(exe))
                    throw new FileNotFoundException();
                if (output == null)
                    throw new ArgumentNullException("output");
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = false;
                psi.RedirectStandardError = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                psi.ErrorDialog = false;
                psi.WorkingDirectory = Environment.CurrentDirectory;
                psi.FileName = FindExePath("cdrecord.exe"); //see http://csharptest.net/?p=526
                psi.Arguments = " -scanbus -v"; // see http://csharptest.net/?p=529
                using (Process process = Process.Start(psi))
                using (ManualResetEvent mreOut = new ManualResetEvent(false),
                mreErr = new ManualResetEvent(false))
                {
                    process.OutputDataReceived += (o, e) => { if (e.Data == null) mreOut.Set(); else output(e.Data); };
                    process.BeginOutputReadLine();
                    
                    process.ErrorDataReceived += (o, e) => { if (e.Data == null) mreErr.Set(); else output(e.Data); };
                    process.BeginErrorReadLine();
                    output = s => ShowWindowsMessage(s);
                    process.StandardInput.Close();
                    process.WaitForExit();
                    mreOut.WaitOne();
                    mreErr.WaitOne();
                    
                    return process.ExitCode;
                }
            }
            public static string FindExePath(string exe)
            {
                exe = Environment.ExpandEnvironmentVariables(exe);
                if (!File.Exists(exe))
                {
                    if (Path.GetDirectoryName(exe) == String.Empty)
                    {
                        foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
                        {
                            string path = test.Trim();
                            if (!String.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exe)))
                                return Path.GetFullPath(path);
                        }
                    }
                    throw new FileNotFoundException(new FileNotFoundException().Message, exe);
                }
                return Path.GetFullPath(exe);
            }
        private static void ShowWindowsMessage(string message)
        {
            MessageBox.Show(message);
        }
