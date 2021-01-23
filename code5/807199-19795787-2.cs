    public static int CountLines1(string path)
    {
       int lineCount = 0;
       bool skipNextLineBreak = false;
       bool startedLine = false;
       var buffer = new char[16384];
       int readChars;
       
       using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length))
       using (var reader = new StreamReader(stream, Encoding.UTF8, false, buffer.Length, false))
       {
          while ((readChars = reader.Read(buffer, 0, buffer.Length)) > 0)
          {
             for (int i = 0; i < readChars; i++)
             {
                switch (buffer[i])
                {
                   case '\n':
                   {
                      if (skipNextLineBreak)
                      {
                         skipNextLineBreak = false;
                      }
                      else
                      {
                         lineCount++;
                         startedLine = false;
                      }
                      break;
                   }
                   case '\r':
                   {
                      lineCount++;
                      skipNextLineBreak = true;
                      startedLine = false;
                      break;
                   }
                   default:
                   {
                      skipNextLineBreak = false;
                      startedLine = true;
                      break;
                   }
                }
             }
          }
       }
       
       return startedLine ? lineCount + 1 : lineCount;
    }
