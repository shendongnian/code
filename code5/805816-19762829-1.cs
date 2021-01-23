    public IList<BrandInfo> SearchProduct(string name)
    {
        AuthenicationServiceClient obj = new AuthenicationServiceClient();
        return obj.SearchProducts(name).Select(Convert).ToList(); 
    }
    public Models.BrandInfo Convert(Model.BrandInfo x)
    {
        //your clone work here. 
    }
