    Logger logger = new Logger();
    logger.Error += delegate(object sender, LogErrorEventArgs e)
    {
        if (SystemInformation.UserInteractive)
            MessageBox.Show(e.ExceptionToLog.Message);
    };
