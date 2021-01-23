    using System.Data.Entity; //namespace
    from c in Contacts.Where(a => a.LastName.Contains("Anderson"))               
                       select new
                       {
                           Id = c.Id,
                           Surname= c.LastName,
                           TheirTime = c.TimeZoneOffset,
                           CalculatedTime = DbFunctions.AddMinutes(c.SavedUtcTime,x.UtcOffsetInMinutes)                  
                       }
