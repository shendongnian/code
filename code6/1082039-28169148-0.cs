    DateTime? currentStartDatetime = null;
    DateTime? currentStartDatetime = null;
    string line;  // can use string builder for performance..
          
    foreach (var profile in profiles)
    {
      line = string.Empty;
    
      if (currentStartDateTime != profile.StartDateTime)
      {
         currentStartDateTime = profile.StartDateTime;
         line += profile.StartDateTime + ",";
      }
      else
      {
         line += ",";
      }
    
      if (currentEndDateTime != profile.EndDateTime)
      {
         currentEndDateTime = profile.EndDateTime;
         line += profile.EndDateTime + ",";
      }
      else
      {
         line += ",";
      }
      line += profile.Volume;
    
      Csv.WriteLine(line);
    }
