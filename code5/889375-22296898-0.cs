    [Key]
    public string CartItemId { get; set; }
    public string CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public System.DateTime DateCreated { get; set; }
    public virtual Product Product { get; set; }
}
    
