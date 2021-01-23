    public static void Follow(string path)
    {
        // Note the FileShare.ReadWrite, allowing others to modify the file
        using (FileStream fileStream = File.Open(path, FileMode.Open, 
            FileAccess.Read, FileShare.ReadWrite))
        {
            fileStream.Seek(0, SeekOrigin.End);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                for (;;)
                {
                    // Substitute a different timespan if required.
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    // Write the output to the screen or do something different.
                    // If you want newlines, search the return value of "ReadToEnd"
                    // for Environment.NewLine.
                    Console.Out.Write(streamReader.ReadToEnd());
                }
            }
        }
    }
