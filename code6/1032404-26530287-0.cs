    var hasFailed = false;
    // Set up process
    p.OutputDataReceived += new DataReceivedEventHandler(
        delegate (object sender, DataReceivedEventArgs e)
        {
            if (e.Data == "FAIL") hasFailed = true;
        }
    );
    // Start Process
    p.WaitForExit();
    if(hasFailed)
    {
        // Handle the fact that the process failed and return appropriately.
    }
    // Otherwise the process succeeded and we can return normally.
