    try {
        File.AppendAllText("Exceptions.log", (e.ExceptionObject as Exception).Message);
    }
    finally {
        Environment.Exit(1);
    }
