        const string BATFILE = "Test.bat";
        const bool HIDE = true;
        static Encoding ENCODING = Encoding.Default;
        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd", BATFILE);
            
            if (HIDE)
            {
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }
            psi.RedirectStandardOutput = true;
            psi.StandardOutputEncoding = ENCODING;
            psi.UseShellExecute = false;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.OutputDataReceived += p_OutputDataReceived;
            p.Start();
        }
        static void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            //Do something with a form...
            System.Console.WriteLine(e.Data);
        }
