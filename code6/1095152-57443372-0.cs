    public void Processing()
    {
        //Create and start the ffmpeg process
        System.Diagnostics.ProcessStartInfo psi = new ProcessStartInfo("ffmpeg")
        { // this is fully command argument you can make it according to user input 
            Arguments = "-y -i  '/mnt/Disk2/Video/Antina03.jpg' pp.mp4 ",
            RedirectStandardOutput = true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            UseShellExecute = false,
            RedirectStandardError=true,
            RedirectStandardInput=true
        };
        System.Diagnostics.Process ischk;
        ischk = System.Diagnostics.Process.Start(psi);
        ischk.WaitForExit();
        ////Create a streamreader to capture the output of ischk
        System.IO.StreamReader ischkout = ischk.StandardOutput;
        ischk.WaitForExit();
        if (ischk.HasExited) // this condition very important to make asynchronous output  
        {
            string output = ischkout.ReadToEnd();
            out0 = output;
        }
        /// in case you got error message 
        System.IO.StreamReader iserror = ischk.StandardError;
        ischk.WaitForExit();
        if (ischk.HasExited)
        {
            string output = iserror.ReadToEnd();
            out0 = output;
        }
 
    }
