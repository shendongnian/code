                Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = @"C:\inetpub\wwwroot\DelTemp\Scripts\PsExec.exe";
            p.StartInfo.Arguments = "\\\\" + li.Text + " -u XXXX\\xxxxxx -p xxxxxxxxxxx -accepteula -i 0 -d c:\\windows\\system32\\cscript.exe /nologo \\\\testusit2\\C$\\karthik\\DelTemp-Final.vbs";
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            txtValueA.Text += "PSexec argument :" + p.StartInfo.Arguments;
            txtValueA.Text += "<br/> Output : " + output + "| error messsage: " + errormessage;
        }
        public static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
        //Standard output event handler for PSEXEC
        public static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
