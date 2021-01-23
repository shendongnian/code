    private void process_DataReceived(object sender, DataReceivedEventArgs e)
    {
        // null data means we've received everything
        if (e.Data == null) {
            process.CancelOutputRead();
            process.CancelErrorRead();
            return;
        }
        
        // e.Data is the string with the output from the process
        Console.Write(e.Data);
    }
