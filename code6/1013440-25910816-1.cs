    public List<UserDataResponse> JSONDataAll()
    {
        var users = (from u in db.Tbl_Users
                    select new UserDataResponse
                    {
                        UserName = u.UserName,
                        UserAddress = u.UserAddress
                    });
        return users.ToList();
    }
