    static void outputRedirection(object sendingProcess, 
                                  DataReceivedEventArgs outLine)
    {
        try
        {
            if (outLine.Data != null)
                Console.WriteLine(outLine.Data);
                // or collect the data, etc
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
