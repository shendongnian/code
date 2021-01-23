    public Func<bool,Products> Filter()
    {
        return i => i.Brand == "Nike"
    }
    public Func<bool,Products> Filter(string brandName)
    {
        return i => i.Brand == brandName;
    }
    //usage:
    db.Products.Where(Filter());
    //or
    db.Products.Where(Filter("Nike"));
