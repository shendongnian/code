    IDictionary<string,IList<User>> res = new UserService()
        .GetUsers(id.Value, pageNumber: _pageNum)
        .GroupBy(x=>x.Name.Substring(0,1))
        .ToDictionary(
            g => g.Key
        ,   g => (IList<User>)g.ToList()
        );
