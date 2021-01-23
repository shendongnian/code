    private string _sku; 
    public virtual string Sku
    {
        get { return Product.Id.Trim(); }
        set { _sku = value; }
    }
