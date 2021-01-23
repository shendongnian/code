    using (var cSharp = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Write | FileShare.Delete))
    {
        // The Python service will be able to change and to rename the file:
        using (var python = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.Read))
        {
        }
        File.Move(filename, newFilename);
    }
