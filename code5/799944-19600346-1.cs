    /// <summary>
    /// Contains the received data.
    /// </summary>
    private string receivedData = string.Empty;
    /// <summary>
    /// Starts a process, passes some arguments to it and retrieves the output written.
    /// </summary>
    /// <param name="filename">The filename of the executable to be started.</param>
    /// <param name="arguments">The arguments to be passed to the executable.</param>
    private void ExecuteProcess(string filename, string arguments)
    {
        Process p = new Process();
        
        // Define the startinfo parameters like redirecting the output.
        p.StartInfo = new ProcessStartInfo(filename, arguments);
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.OutputDataReceived += this.OutputDataReceived;
        
        // Start the process and also start reading received output.
        p.Start();
        p.BeginOutputReadLine();
        // Wait until the process exits.
        p.WaitForExit();
    }
    /// <summary>
    /// Is called every time output data has been received.
    /// </summary>
    /// <param name="sender">The sender of this callback method.</param>
    /// <param name="e">The DataReceivedEventArgs that contain the received data.</param>
    private void OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        this.receivedData += e.Data;
    }
