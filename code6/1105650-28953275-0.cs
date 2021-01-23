    /// <summary>
    /// This is used to store all the above information in, while still maintaining the automated index count from the internal for loop link builder.
    /// 
    /// Don't forget to pass the index into this!
    /// </summary>
    public Func<int, object> PaginationLinkData
    {
        get
        {
            dynamic res = new ExpandoObject();
            res.amount = Amount;
            if (Sort != null) res.sort = Sort;
            if (Order != null) res.order = Order;
            return index =>
            {
                res.page = index;
                return res;
            };
        }
    }
