    private static string GetCurrentDriveLetter()
    {
        return Path.GetPathRoot(Environment.CurrentDirectory); // Alternatively, if you believe the working directory may be different
        // return Path.GetPathRoot(Assembly.GetExecutingAssembly().Location);
    }
