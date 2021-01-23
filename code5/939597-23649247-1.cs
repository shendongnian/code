    [Bind(Exclude="CompanyId,TenantId")]
    public class CustomerModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; } // user cannot inject
        public int TenantId { get; set; }  // ..
        public string Name { get; set; }
        public string Phone { get; set; }
        // ...
    }
