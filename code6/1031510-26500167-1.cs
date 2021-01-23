    public IEnumerable<Filter> GetFilter(Filter filter)
    {
        var query =
            from sub in Subscriptions
            join u in Users
            on sub.UserID equals u.Id
            join od in Order_Details1
            on sub.OD_Id equals od.OD_Id
            join p in Products
            on od.ProductId equals p.ProductId
            where p.Type == "Testing"
            select new Filter
            {
                //do something
            };
            query = ConditionalAttribute(query, filter);
