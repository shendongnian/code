    // define a class-level field variable
    private int counter;
    private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        counter++;
        // Only print to the console once every 500 times the event fires,
        //  which was about once per second when I tested it
        if (counter % 500 == 0)
        {
            //Prints: "Downloaded 3mb of 61.46mb  (4%)"
            Console.WriteLine("Downloaded "
                              + ((e.BytesReceived / 1024f) / 1024f).ToString("#0.##") + "mb"
                              + " of "
                              + ((e.TotalBytesToReceive / 1024f) / 1024f).ToString("#0.##") + "mb"
                              + "  (" + e.ProgressPercentage + "%)"
                );
        }
    }
