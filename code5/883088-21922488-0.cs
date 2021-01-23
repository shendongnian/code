    public partial class Submission
    {       
        public int Keytbl { get; set; }
        public int Company { get; set; }
        public virtual tbl_lst_Company tbl_lst_Company{ get; set; }        
    }
    public partial class tbl_lst_Company
    {       
	public tbl_lst_Company() {
            this.Submissions = new List<Submission>();
	}
        public int CompanyID { get; set; }
        public string Company { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
    public tbl_lst_CompanyMap()
    {
        // Primary Key
        this.HasKey(t => t.CompanyID);
        // Properties
        this.Property(t => t.Company)
            .IsRequired()
            .HasMaxLength(150);
        // Table & Column Mappings
        this.ToTable("tbl_lst_Company");
        this.Property(t => t.CompanyID).HasColumnName("CompanyID");
        this.Property(t => t.Company).HasColumnName("Company");
    }
    public SubmissionMap()
    {
        // Primary Key
        this.HasKey(t => t.Keytbl);
        // Table & Column Mappings
        this.ToTable("Submissions");
        this.Property(t => t.Keytbl).HasColumnName("Keytbl");
        this.Property(t => t.Company).HasColumnName("Company");
        this.HasOptional(t => t.tbl_lst_Company)
        .WithMany(t => t.Submissions)
	.HasForeignKey(d => d.Company);
    }
