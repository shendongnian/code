    public IList<BrandInfo> SearchProduct(string name)
    {
        AuthenicationServiceClient obj = new AuthenicationServiceClient();
        return obj.SearchProducts(name).ToList();
    }
