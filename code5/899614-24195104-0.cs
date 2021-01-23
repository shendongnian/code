        string[] files;
        if (Environment.Is64BitOperatingSystem)
        {
            files = Directory.GetFiles("C:\\WINDOWS\\SYSNATIVE\\GROUPPOLICY\\MACHINE");
        }
        else
        {
            files = Directory.GetFiles("C:\\WINDOWS\\SYSTEM32\\GROUPPOLICY\\MACHINE");
        }
        foreach (string file in files)
        {
            System.Console.WriteLine(file);
        }
