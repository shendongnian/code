    int? keywordID = DataContext.Keywords.Where(x => x.Name == keywordFilter).Select(x => x.Id).FirstOrDefault();
    
    if(keywordID != null)
    {
        getGroup = DataContext.Groups.FirstOrDefault(group => group.Keywords.Any(kw => kw.Id == keywordID));
    }
  
