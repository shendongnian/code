    string Path = System.IO.Path.GetDirectoryName(...);
    // StreamReader SourceStream = new StreamReader(Path);
    // Request.UseBinary = true;
    byte[] FileContents = File.ReadAllBytes(Path);
    // SourceStream.Close();
