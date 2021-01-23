    // Local field to store the files enumerator;
    IEnumerator<string> filesEnumerator;
    // You would want to make this call, at appropriate time in your code.
    filesEnumerator = Directory.EnumerateFiles(folderPath).GetEnumerator();
    // You can wrap the calls to MoveNext, and Current property in a simple wrapper method..
    // Can also add your error handling here.
    public static string GetNextFile()
    {
        if (filesEnumerator != null && filesEnumerator.MoveNext())
        {
            return filesEnumerator.Current;
        }
        // You can choose to throw exception if you like..
        // How you handle things like this, is up to you.
        return null;
    }
    // Call GetNextFile() whenever you user clicks the next button on your UI.
