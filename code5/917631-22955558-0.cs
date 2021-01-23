    private void reg(string host)
                {
        
                    string build = "QUERY \\\\" + host + "\\HKEY_USERS";
                    string parms = @build;
                    string output = "";
                    string error = string.Empty;
        
                    ProcessStartInfo psi = new ProcessStartInfo("reg.exe", parms);
        
                    psi.RedirectStandardOutput = true;
                    psi.RedirectStandardError = true;
                    psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    psi.UseShellExecute = false;
                    System.Diagnostics.Process reg;
                    reg = System.Diagnostics.Process.Start(psi);
                    using (System.IO.StreamReader myOutput = reg.StandardOutput)
                    {
                        output = myOutput.ReadToEnd();
                    }
                    using (System.IO.StreamReader myError = reg.StandardError)
                    {
                        error = myError.ReadToEnd();
        
                    }
                    Output.AppendText(output + "\n");
        
        
                }  ``
