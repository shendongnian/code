    public IEnumerable<ProjectName.Shared.Models.Views.User> GetTheUsers() {
        // do something here...
  
        return new UserService().GetUsers(id.Value, pageNumber: _pageNum);
    }
