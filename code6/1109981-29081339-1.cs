         Process p = Process.Start(@"C:\...\example.exe");
         p.OutputDataReceived += p_OutputDataReceived;
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
