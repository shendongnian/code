    [HttpGet]
    public PageResult<Merchant> MerchantList(
        ODataQueryOptions<Merchant> queryOptions)
    {
        var t = new ODataValidationSettings() { MaxTop = 25 };
        var s = new ODataQuerySettings() { PageSize = 25 };
        queryOptions.Validate(t);
        IEnumerable<Merchant> results =
            (IEnumerable<Merchant>)queryOptions.ApplyTo(_repo.Context.Merchants, s);
        int skip = queryOptions.Skip == null ? 0 : queryOptions.Skip.Value;
        int take = queryOptions.Top == null ? 25 : queryOptions.Top.Value;
        long? count = Request.GetInlineCount();
        List<Merchant> pageOfResults = results.Skip(skip).Take(take).ToList();
        PageResult<Merchant> page =
            new PageResult<Merchant>(
                pageOfResults, 
                Request.GetNextPageLink(), 
                Request.GetInlineCount());
        foreach (var item in page)
        {
            // Total Stores
            item.TotalStores = myMethod(item.MerchantUID);
        }
        return page;
    }
