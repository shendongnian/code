    private static void SanityCheck()
    { 
        if (!Directory.Exists(sDrive))
        {
           Console.WriteLine("FATAL: Disk drive doesn't exist.");
        }
        else if (!Directory.Exists(Path.Combine(sDrive, sFolder))
        {
           Console.WriteLine("FATAL: Root folder doesn't exist.");
        }
        else if (!Directory.Exists(Path.Combine(sDrive, sFolder, sDivFolder))
        {
            Console.WriteLine("FATAL: Div folder doesn't exist.");
        }
        else
        {
            bSanity = true;
        }
    }  
