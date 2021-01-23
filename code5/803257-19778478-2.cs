    // Hold a collection of QBO items
    private ReadOnlyCollection<Item> _Items;
    // I set the collection in the constructor only once
    public Invoices(Entities.IPPRestProfile restProfile)
    {
        if (restProfile == null)
            throw new ArgumentException("IPPRestProfile object is required.", "restProfile");
        OAuthRequestValidator oAuthValidator = new OAuthRequestValidator(restProfile.OAuthAccessToken, restProfile.OAuthAccessTokenSecret,
                restProfile.ConsumerKey, restProfile.ConsumerSecret);
        ServiceContext context = new ServiceContext(restProfile.RealmId, restProfile.DataSource, oAuthValidator);
        _Service = new DataService(context);
        _Items = (new QueryService<Item>(context)).ExecuteIdsQuery("SELECT * FROM Item", QueryOperationType.query);
    }
    
