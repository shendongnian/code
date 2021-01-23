            System.Diagnostics.ProcessStartInfo psi =
                    new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
           
            System.Diagnostics.Process proc =
                       System.Diagnostics.Process.Start(psi);
                       
            System.IO.StreamReader strm = proc.StandardError;
           
            System.IO.StreamReader sOut = proc.StandardOutput;
                       
            System.IO.StreamWriter sIn = proc.StandardInput;
                        sIn.WriteLine("d:");//this line moves you to the d drive  
            sIn.WriteLine("cd "+Server.MapPath("Screenshot").ToString());//here screenshot is a my directory which containing the my .exe you can chamge it with yours 
            sIn.WriteLine(exec);//here your exe runs
            strm.Close();
           sIn.WriteLine("EXIT");
           proc.Close();
           string results = sOut.ReadToEnd().Trim();
            sIn.Close();
            sOut.Close();
