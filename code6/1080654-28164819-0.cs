        //declare a dictionary 
        Dictionary<string, string> someDictionary = new Dictionary<string, string> ();
    
    
        using (ServiceContext svcContext = new ServiceContext(_serviceProxy))
         {
           var query_where3 = from c in svcContext.ContactSet
                             join a in svcContext.AccountSet
                             on c.ContactId equals a.PrimaryContactId.Id
                             where  c.FullName.Contains("Caf")
                             select new
                             {
                              account_name = a.Name,
                              contact_name = c.LastName
                             };
    }
    //then
        foreach(var q in query_where3)
        {
            if(string.IsNullOrEmpty(account_name)==false && string.IsNullOrEmpty(contact_name)==false)
        {
            someDictionary.Add(account_name, contact_name);
        }
        }
//then you can add the .Normalize(NormalizationForm.FormD) to your dictionary 
