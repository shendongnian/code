    public IEnumerable<IGrouping<string, User>> GetUser(int? id, int? pageNumber)
    {
        int _pageNum = pageNumber.HasValue ? pageNumber.Value : 1;
        return new UserService().GetUsers(id.Value, pageNumber: _pageNum).GroupBy(x => x.Name.Substring(0, 1));
    }
