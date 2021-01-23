    try
    {
        string path = Path.Combine(Path.GetTempPath(), "MyApp_PDF_32");
        Converter = new ThreadSafeConverter(
                      new RemotingToolset<PdfToolset>(
                           new Win32EmbeddedDeployment(
                               new StaticDeployment(path))));
    }
    catch (Exception e)
    {
        if (e.Message.StartsWith("Unable to load DLL 'wkhtmltox.dll'"))
        {
            throw new InvalidOperationException(
            "Ensure the prerequisite C++ 2013 Redistributable is installed", e);
        }
        else
            throw;
    }
