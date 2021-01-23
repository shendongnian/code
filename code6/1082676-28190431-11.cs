    public QueryResponse<Purchase> Any(CustomPurchase request)
    {
        var qPurchase = request.ConvertTo<QueryPurchase>();
    
        if (request.BuyerName != null)
        {
            qPurchase.BuyerIds = Db.Column<int>(Db.From<Person>()
                .Where(x => x.Name == request.BuyerName)
                .Select(x => x.Id));
        }
    
        if (request.SellerName != null)
        {
            qPurchase.SellerIds = Db.Column<int>(Db.From<Person>()
                .Where(x => x.Name == request.SellerName)
                .Select(x => x.Id));
        }
    
        var q = AutoQuery.CreateQuery(qPurchase, Request.GetRequestParams());
    
        return AutoQuery.Execute(qPurchase, q);
    }
