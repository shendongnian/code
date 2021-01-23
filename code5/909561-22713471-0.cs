    foreach(var user in moreUsers) {
        List<User> list;
        if(!mutable.TryGetValue(user.Country, out list)) {
            mutable.Add(user.Country, list = new List<User>());
        }
        list.Add(user);
    }
