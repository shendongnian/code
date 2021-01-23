    System.Diagnostics.Process p = new System.Diagnostics.Process();            
                p.StartInfo.FileName = "PATH TO YOUR FILE";
                p.EnableRaisingEvents = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.Arguments = metalType + " " + graphHeight + " " + graphWidth;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;              
                p.Start();            
                svgText = p.StandardOutput..ReadToEnd();
    
                StreamReader s = p.StandardError;
                string error = sr.ReadToEnd();
                p.WaitForExit(20000);
