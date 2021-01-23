    Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(AppDomain.CurrentDomain.BaseDirectory + "\\logs\\app-{Date}.log")
                .WriteTo.ColoredConsole()
                .MinimumLevel.Debug()
                .CreateLogger();
    HostFactory.Run(x => {
            // configure TopShelf to use Serilog's global instance.
            x.UseSerilog();
    }
