    public static void ToFile(this FileResult fileResult, string fileName)
    {
        if (fileResult is FileContentResult)
        {
            File.WriteAllBytes(fileName, ((FileContentResult)fileResult).FileContents);
        }
        else if (fileResult is FilePathResult)
        {
            //File.Copy
        }
        else if ()
        {
            //write the stream
        }
        else
        {
            throw new ArgumentException("Unsupported FileResult type");
        }
    }
