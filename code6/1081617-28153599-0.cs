    public List<objectX> GetObjectX()
        {
            return new List<objectX>() { new objectX() { CompanyName = "c1", BranchName = "b1" },
            new objectX() { CompanyName = "c2", BranchName = "b2" }};
        }
    public class objectX
        {
            public string CompanyName { get; set; }
            public string Username { get; set; }
            public string BranchName { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public int Id { get; set; }
            public int ClientId { get; set; }
            public int UserId { get; set; }
            public int TypeId { get; set; }
            public int Credits { get; set; }
            public System.DateTime InvoiceDate { get; set; }
            public string Notes { get; set; }
            public Nullable<int> LinkedId { get; set; }
            public string Status { get; set; }
            public Nullable<System.DateTime> DateProcessed { get; set; }
            public Nullable<int> ProcessedBy { get; set; }
            public int BranchId { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<int> CreatedBy { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
            public Nullable<int> ModifiedBy { get; set; }
        }
