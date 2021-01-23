    public static int CountLines(string path)
    {
       int lineCount = 0;
       using (var reader = File.OpenText(path))
       {
          while (true)
          {
             switch (reader.Read())
             {
                case -1:
                {
                   return lineCount;
                }
                case 10:
                {
                   lineCount++;
                   break;
                }
                case 13:
                {
                   if (reader.Peek() == 10)
                   {
                      reader.Read();
                   }
                   
                   lineCount++;
                   break;
                }
    			default:
    			{
    			   if (lineCount == 0)
    			   {
    			      lineCount = 1;
    			   }
    			   break;
    			}
             }
          }
       }
    }
