    private static string CreatePdf(string fileName){
    
            string command = "gswin32c -q -dNOPAUSE -sDEVICE=pdfwrite -sOutputFile=\"" + 
        			fileName + ".pdf\"  -fc:\\output.ps";
        
            Console.WriteLine(command);
            Process p = new Process();
        
            StreamWriter sw;
            StreamReader sr;
                    
            ProcessStartInfo info = new ProcessStartInfo("cmd");
            info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Current directory: " + info.WorkingDirectory);
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
                    
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
                    
            p.StartInfo = info;
            p.Start();
                    
            sw = p.StandardInput;
            sr = p.StandardOutput;
            sw.AutoFlush = true;
                    
            sw.WriteLine(command);
                    
            sw.Close();
                    
            string ret = sr.ReadToEnd();
        
            Console.WriteLine(ret);
            return ret;
        }
