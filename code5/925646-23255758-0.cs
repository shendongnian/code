            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            Process proc = Process.Start(psi);
            // Open the batch file for reading
            
            // Attach the output for reading
            StreamReader sOut = proc.StandardOutput;
            StreamReader sErr = proc.StandardError;    
            
            // Attach the in for writing
            StreamWriter sIn = proc.StandardInput;
            // Write each line of the batch file to standard input
            while (sr.Peek() != -1)
            {
                sIn.WriteLine("ftp");
                sIn.WriteLine("open remote-server-name");
                sIn.WriteLine("username");
                sIn.WriteLine("password");
                sIn.WriteLine("ls");
            }
            
            string outPutStuff= sOut.ReadToEnd();
            proc.WaitForExit();  //this does not appear to be needed. 
            string outErrStuff = sErr.ReadToEnd();
    
            Console.WriteLine("Start FileTransfer FTP Output");
            Console.WriteLine(outPutStuff);
            Console.WriteLine("Any errors follow this line---");
            Console.WriteLine(outErrStuff);
           
            Console.WriteLine(outPutStuff);
    
            sOut.Close();
            sIn.Close();
