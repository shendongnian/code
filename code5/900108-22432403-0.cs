    public Logger()
    {
        loggers.Add(new OutputWindowLogMedia ());
        loggers.Add(new TextFileLogMedia ());
        loggers.Add(new EmailLogMedia ());
    }
