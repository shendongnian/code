    public IEnumerable<ProjectName.Shared.Models.Views.User> GetTheUsers() {
        // do something here...
  
        return new UserService()
                 .GetUsers(id.Value, pageNumber: _pageNum)
                 .GroupBy(x=>x.Name.Substring(0,1));
    }
