    public virtual string Sku
    {
        get { return Product.Id.Trim(); }
        set { Product.Id = value; }
    }
