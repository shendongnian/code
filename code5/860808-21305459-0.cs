    public string getColumnWithNum(string source)
    {
         string tmp = source;
         if (tmp.StartsWith("Column"))
         {
              tmp.Replace("Column", "");
              UInt32 num
              if (UInt32.TryParse(tmp, out num)
              {
                   return source; // matched
              }
         }
         return ""; // not matched
    }
