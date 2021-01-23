    public class Report
    {
        public int ReportId { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
    }
	public class Model
    {
        public int ModelId {get; set;}
        public Report Report { get; set; }
        public int ReportId { get; set; }
    }
	public class ReportConfiguration : EntityTypeConfiguration<Report>
    {
        public ReportConfiguration()
        {
            this.ToTable("Report");
            this.HasOptional(m => m.Model).WithMany().HasForeignKey(m => m.ModelId).WillCascadeOnDelete(false);
        }
    }
