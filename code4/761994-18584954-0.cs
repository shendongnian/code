     string filename = optionFileNameFormat; // "{year}-{month}-{day} {name}"
     Dictionary<string, string> tagList = new Dictionary<string, string>();
     tagList.Add("author",System.Security.Principal.WindowsIdentity.GetCurrent().Name);
     tagList.Add("year" , "" + DateTime.Now.Year);
     tagList.Add("month", "" + DateTime.Now.Month);
     tagList.Add("day"  , "" + DateTime.Now.Day);
     foreach (var property in tagList)
     {
      filename= filename.Replace(@"{" + property.Key + @"}", property.Value);
     }
