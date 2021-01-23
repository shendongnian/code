    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string ReportName { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
