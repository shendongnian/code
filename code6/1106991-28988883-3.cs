    public static void ToFile(this FileResult fileResult, string fileName)
    {
        if (fileResult is FileContentResult)
        {
            File.WriteAllBytes(fileName, ((FileContentResult)fileResult).FileContents);
        }
        else if (fileResult is FilePathResult)
        {
            File.Copy(((FilePathResult)fileResult).FileName, fileName, true); //overwrite file if it already exists
        }
        else if (fileResult is FileStreamResult)
        {
            //from http://stackoverflow.com/questions/411592/how-do-i-save-a-stream-to-a-file-in-c
            using (var fileStream = File.Create(filename))
            {
                var fileStreamResult = (FileStreamResult)fileResult;
                fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin);
                fileStreamResult.FileStream.CopyTo(fileStream);
                fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin); //reset position to beginning. If there's any chance the FileResult will be used by a future method, this will ensure it gets left in a usable state - Suggestion by Steven Liekens
            }
        }
        else
        {
            throw new ArgumentException("Unsupported FileResult type");
        }
    }
