    IQueryable<User> users = Context.Users;
    
    if (firstName != null)
        users = users.Where(x => x.FirstName == firstName);
    if(lastName != null)
        users = users.Where(x => x.LastName == lastName);
    List<SearchResultViewModel> model = users.Select(x => new SearchResultViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                JobTitle = x.JobTitle
                // and so forth for whatever fields you need to return...
            });
