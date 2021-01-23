    public class Product
    {
      [Key]
      public int ProductID { get; set; }
      public string ProductName { get; set; }
      public ICollection<Report> ProductReports { get; set; }
    }
    public class Report
    {
      [Key]
      public int ReportID { get; set; }
      public string ReportName { get; set; }
      public int ProductID { get; set; }
      public virtual Product Product { get; set; }
    }
