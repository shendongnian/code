    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
        try
        {
            Interlocked.Increment(ref globalStopFlag);
    
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Program interrupted..deleting corrupted file");
            Console.ResetColor();
            if (File.Exists(fileInProgress))
            {
                while (IsFileLocked(fileInProgress))
                {
                    System.Threading.Thread.Sleep(1000);
                }
                File.Delete(fileInProgress);
            }
        }
        catch
        {
            Console.WriteLine("Error occured.");
        }
    }
    
    void SomeDownloadFunction()
    {
       using (somefile)
       {
         while (!downloadFinished)
        {
            long doINeedToStop = Interlocked.Read(ref   globalStopFlag)
    
            if (doINeedToStop != 0)
              return;
    
            //Download the next set of packets and write them to somefile
        }
       }
    }
