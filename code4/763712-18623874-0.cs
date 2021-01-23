    public CartItem
    {
       public int Id { get; set; }
       public string Desc { get; set; }
    }
    public CartDetails
    {
       public int Id { get; set; }
       public List<CartItem> CartItems { get; set; }
       public Decimal Tax { get; set; }
       public Decimal Total { get; set; }
    }
