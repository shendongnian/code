    using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite)) 
    {
        var sw = new StreamWriter(fs);
        var sr = new StreamReader(fs);
        while(!streamReader.EndOfStream)
        {
            var line = sr.ReadLine();
            //Do stuff with line.
            //...
            if (macExists)
            {
               //Increment the number, Note that in here we can only replace characters,
               //We can't insert extra characters unless we rewrite the rest of the file
               //Probably more hassle than it's worth but
               //You could have a fixed number of characters like 000001 or     1
               //Read the number as a string,
               //Int.Parse to get the number
               //Increment it
               //work out the number of bytes in the line.
               //get the stream position
               //seek back to the beginning of the line
               //Overwrite the whole line with the same number of bytes.
            }
            else
            {
                //Append a line, also harder to do with streams like this.
                //Store the current position,
                //Seek to the end of the file,
                //WriteLine
                //Seek back again.
            }
        }
    }
