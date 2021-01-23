    var username = HttpContext.Current.User.Identity.Name;
    var taskList = countries.Select(c => Task.Factory.StartNew(() =>
    {
      UserContext.Username = username;
      return new Dictionary<FileName, FileDetails> { { c, GetFilesInCountry(query, c) } };
    
    })).ToList();
