    public static int CountLines(string path)
    {
       int lineCount = 0;
       bool skipNextLineBreak = false;
       bool startedLine = false;
       
       using (var reader = File.OpenText(path))
       {
          while (true)
          {
             switch (reader.Read())
             {
                case -1:
                {
                   return startedLine ? lineCount + 1 : lineCount;
                }
                case 10:
                {
                   if (skipNextLineBreak)
                   {
                      skipNextLineBreak = false;
                   }
                   else if (startedLine)
                   {
                      lineCount++;
                      startedLine = false;
                   }
                   break;
                }
                case 13:
                {
                   if (startedLine)
                   {
                      lineCount++;
                      startedLine = false;
                   }
                   
                   skipNextLineBreak = true;
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
