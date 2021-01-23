    public interface IProduct
    {
        int ID{ get; set; }
        string ModelNumber { get; set; }
        string SKU { get; set; }
    }
    public Class Product : IProduct
    {
       public int ID{ get; set; }
       public string ModelNumber { get; set; }
       public string SKU { get; set; }
       public string Att4 { get; set; }
       public string Att5 { get; set; }
    }
