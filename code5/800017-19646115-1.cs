    /// <summary>
    /// Converts the specified source file and saves it as pdf with the
    /// specified destination filename.
    /// </summary>
    /// <param name="sourceFilename">The filename of the file to be converted into a pdf.</param>
    /// <param name="destinationFilename">The filename of the pdf.</param>
    /// <exception cref="System.IO.FileNotFoundException">Is thrown if the specified source file does not exist.</exception>
    /// <exception cref="System.Exception">Is thrown if something went wrong during the convertation process.</exception>
    public static void SaveAsPDF(string sourceFilename, string destinationFilename)
    {
        if (!File.Exists(sourceFilename))
        {
            throw new FileNotFoundException(string.Format("The specified file {0} does not exist.", sourceFilename), sourceFilename);
        }
 
        try
        {
            Microsoft.Office.Interop.PowerPoint.Application app = new Microsoft.Office.Interop.PowerPoint.Application();
            app.Presentations.Open(sourceFilename).SaveAs(destinationFilename, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPDF);
            app.Quit();
        }
        catch (Exception e)
        {
            throw new Exception(string.Format("Unable to convert {0} to {1}", sourceFilename, destinationFilename), e);
        }
    }
