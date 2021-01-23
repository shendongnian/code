    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
    string path = baseDir + "Programs\\Logging\\";
    Process logger = new Process();
    // Here's the deal
    logger.StartInfo.WorkingDirectory = path;
    logger.StartInfo.FileName = System.IO.Path.Combine(path, "Logger.exe");
    logger.Start();
