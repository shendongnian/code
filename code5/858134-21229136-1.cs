    StringBuilder sb = new StringBuilder();
    using (StreamReader sr = new StreamReader(fileName)) 
    {
        String line;
        while ((line = sr.ReadLine()) != null) 
        {
            sb.AppendLine(line);
        }
    }
    string content = sb.ToString();
    
    
    // Remove unnecessary tabs and newlines
    string cleanedContent = content.Replace('\t', String.Empty)
                                   .Replace('\r', String.Empty)
                                   .Replace('\n', String.Empty);
