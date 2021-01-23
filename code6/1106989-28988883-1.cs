    public static void ToFile(this FileResult fileResult, string fileName)
    {
        if (fileResult is FileContentResult)
        {
            File.WriteAllBytes(fileName, ((FileContentResult)fileResult).FileContents);
        }
        else if (fileResult is FilePathResult)
        {
            File.Copy(((FilePathResult)fileResult).FileName, fileName, true);
        }
        else if (fileResult is FileStreamResult)
        {
            //from http://stackoverflow.com/questions/411592/how-do-i-save-a-stream-to-a-file-in-c
            var fileStream = File.Create(filename);
            var fileStreamResult = (FileStreamResult)fileResult;
            fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin);
            fileStreamResult.FileStream.CopyTo(fileStream);
            fileStream.Close();
        }
        else
        {
            throw new ArgumentException("Unsupported FileResult type");
        }
    }
