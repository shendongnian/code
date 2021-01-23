    [HttpPost]
    public List<User> GetUserList(UserListRequest obj)
    {
        List<User> list = new List<User>();
        list.Add(new User { ID = obj.UserId });
        list.Add(new User { ID = obj.UserId + 1 }); //something
        return list;
    }
