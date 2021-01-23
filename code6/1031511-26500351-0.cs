    public IEnumerable<Filter> GetFilter(Filter filter)
    {
        var y = ConditionalAttribute(filter);
        
        IEnumerable<User> filteredUsers = Users;
        if(!string.IsNullOrEmpty(filter.FirstName))
        {
            filteredUsers = filteredUsers.Where(u => u.First_Name == filter.FirstName);
        }
        var query =
            from sub in Subscriptions
            join u in filteredUsers
            on sub.UserID equals u.Id
            join od in Order_Details1
            on sub.OD_Id equals od.OD_Id
            join p in Products
            on od.ProductId equals p.ProductId
            where p.Type == "Testing" + y
            select new Filter
            {
                //do something
            };
