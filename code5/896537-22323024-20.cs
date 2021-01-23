    private DateTime today;
    [TestInitialize]
    public void Setup()
    {      
        today = DateTime.Today;
        TimeProvider.SetCurrentTime(() => today);
    }
    [TestMethod]
    public void Should_not_be_valid_when_price_is_negative()
    {
        Product product = new Product { Price = -1 };
        Assert.False(product.IsValid);
    }
    [TestMethod]
    public void Should_be_expired_when_expiration_date_is_before_current_time()
    {        
        Product product = new Product { Expire = today.AddDays(-1) };
        Assert.False(product.IsExpired);
    }
    // etc
