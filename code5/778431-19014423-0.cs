    private static void SaveStream(Stream stream, string fileName)
    {
        using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
        {
            var buffer = new byte[1024];
    
            var l = stream.Read(buffer, 0, 1024);
            while (l > 0)
            {
                fs.Write(buffer, 0, l);
                l = stream.Read(buffer, 0, 1024);
            }
            fs.Flush();
        } // end of using will close and dispose fs properly
    }
