    private void getTotalSecondProcessed(string v)
    {
       try
       {
           string[] split = v.Split(' ');
           foreach (var row in split)
           {
               if (row.StartsWith("time="))
               {
                   var time = row.Split('=');
                   Progress = TimeSpan.Parse(time[1]).TotalSeconds;
               }
           }      
           catch{}
       }
  
