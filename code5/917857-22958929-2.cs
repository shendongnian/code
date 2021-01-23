    while (!reader.EndOfStream & !endOfFile)
            {
    
               line = reader.ReadLine();
               var firstGroup = line.Substring(0,12);
               var secondGroup = line.Substring(12, 5);
               var lastGroup = line.Substring(89,5);
    
    
                requestProcessor.ProcessRequest(line);
                strProcessedTokens[i++] = line;
            }
