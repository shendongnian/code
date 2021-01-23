    bool isFirst = true;
    
    using (var reader = new StreamReader(filePath))
    {
        while(!reader.EndOfStream)
        {
            if (isFirst)
            {
                isFirst = false;
                continue;
            }
    
            SetOsnaps(reader.ReadLine());
        }
    }
