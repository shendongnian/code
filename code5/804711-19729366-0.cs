     public string FormatPostingDate(object obj)
     {
         if (obj != null && obj.ToString() != string.Empty)
         {
             DateTime postingDate = Convert.ToDateTime(obj);
             return string.Format("{0:yyyy/MM/dd}", postingDate);
         }
         return string.Empty;
     }
