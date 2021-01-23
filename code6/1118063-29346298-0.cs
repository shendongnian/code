    var username = HttpContext.Current.User.Identity.Name;
    
    var taskList = countries.Select(c => Task.Factory.StartNew(() =>
    {
      return new Dictionary<FileName, FileDetails> { { c, GetFilesInCountry(query, c, username) } };
    
    })).ToList();
