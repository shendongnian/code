    [Table("Products")]
    public class Product
    {
        [Key]
        [DisplayName("ID Prodotto")]
        public long ProductID { get; set; }
        [DisplayName("ID Produttore")]
        public long VendorID { get; set; }
        [DisplayName("Prodotto")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E' richiesto un prodotto")]
        public string Name { get; set; }
        public virtual Vendor Vendor { get; set; }
        [NotMapped]
        [DisplayName("Produttore")]
        public string VendorName { get; set; }
    }
