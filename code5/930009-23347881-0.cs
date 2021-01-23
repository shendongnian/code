    public class SupplierUsers
    {
        public int SupplierUsersId { get;set; }
        public string UserId { get; set; }
        public int SupplierId { get; set; }
        public SupplierUserPermission Permission { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; } 
    }
