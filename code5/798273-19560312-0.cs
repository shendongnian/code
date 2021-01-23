        string splitat(string line, int charcount)
    {
         string toren = "";
         if (charcount>=line.Length)
         {
              return line;
         }
         int totalchars = line.Length;
         int loopcnt = totalchars / charcount;
         int appended = 0;
         for (int i = 0; i < loopcnt; i++)
         {
              toren += line.Substring(appended, charcount) + Environment.NewLine;
              appended += charcount;
              int left = totalchars - appended;
              if (left>0)
              {
                   if (left>charcount)
                   {
                        continue;
                   }
                   else
                   {
                        toren += line.Substring(appended, left) + Environment.NewLine;
                   }
              }
         }
         return toren;
    }
