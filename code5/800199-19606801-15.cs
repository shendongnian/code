    private void process_DataReceived(object sender, DataReceivedEventArgs e)
    {
        // null data means we've received everything
        if (e.Data == null) {
            process.CancelOutputRead();
            process.CancelErrorRead();
            
            // do something with the output:
            Console.Write(process_output);
            
            return;
        }
        
        // append the output to the accumulator
        process_output += e.Data;
    }
