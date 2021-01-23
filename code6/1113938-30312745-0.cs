     public string PhantomJson(string phantomControlFile, params string[] arguments)
            {
                string returnJsonString = String.Empty;
    
                if (!String.IsNullOrEmpty(URL))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        FileName = Path.Combine(PhantomExecutionPath, "phantomjs.exe"),
                        UseShellExecute = false,
                        WorkingDirectory = PhantomExecutionPath,
                        Arguments = @"--proxy-type=none --ignore-ssl-errors=true {1} ""{0}"" {2}".FormatWith(URL, phantomControlFile, 
                            arguments.Any() ? String.Join(" ", arguments) : String.Empty)
                    };
    
                    StringBuilder receivedData = new StringBuilder();
                    using (Process p = Process.Start(startInfo))
                    {
                        p.OutputDataReceived += (o, e) =>
                        {
                            if (e.Data != null && e.Data != "failed")
                            {
                                //returnJsonString = e.Data;
                                receivedData.AppendLine(e.Data);
                            }
                        };
                        p.BeginOutputReadLine();
                        p.WaitForExit();
                    }
                    returnJsonString = receivedData.ToString();
    
                    if (!String.IsNullOrEmpty(returnJsonString))
                    {
                        return returnJsonString;
                    }
                    else
                    {
                        throw new ArgumentNullException("Value returned null. Unable to retrieve data from server");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Url cannot be null");
                }
            }
