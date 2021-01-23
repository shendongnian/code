    using (var fs = File.OpenRead(FileToCopy))
    {
        // position to just beyond where you read before
        fs.Position = previousLength;
        // and update the length for next time
        previousLength = fs.Length;
        // now open a StreamReader and read
        using (var sr = new StreamReader(fs))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                // do something with the line
            }
        }
    }
