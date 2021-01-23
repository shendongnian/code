    /// <summary>
    /// Saves the contents of the <paramref name="data"/> array into a 
    /// file named <paramref name="filename"/> placed in a temporary folder,
    /// and runs the associated application for that file extension
    /// in a separate process.
    /// </summary>
    /// <param name="data">The data array.</param>
    /// <param name="filename">The filename.</param>
    private static void OpenInAnotherApp(byte[] data, string filename)
    {
        var tempFolder = System.IO.Path.GetTempPath();
        filename = System.IO.Path.Combine(tempFolder, filename);
        System.IO.File.WriteAllBytes(filename, data);
        System.Diagnostics.Process.Start(filename);
    }
