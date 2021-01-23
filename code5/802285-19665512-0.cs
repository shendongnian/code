    string path = @"path here";
    File.Create(name).Dispose();  // Kill the lock immediately.
    using (StreamWriter file = new StreamWriter(path, true))
    {
    outer for loop{
    file.WriteLine(strMsg);
    }
    // Stream will close automatically when leaving the using block.
