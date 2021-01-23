    public class AuditInformation
    {
        public long CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public abstract class AuditInfo
    {
        public AuditInformation AuditDetails { get; set; }
        public AuditInfo()
        {
            this.AuditDetails = new AuditInformation();
            this.AuditDetails.CreatedByUserId = 0;
            this.AuditDetails.CreatedDate = DateTime.Now;
        }
    }
    public User : AuditInfo
    {
        private User(){}
        public long Id {get; private set;} // dont ask, inherited legacy database
        public string UserId { get; private set; }
        public string Domain { get; private set; }
    
        //..domain logic etc
    }
    public partial class myContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Conventions.Remove<PluralizingTableNameConvention>();
            mb.ComplexType<Domain.Model.AuditInformation>();
            mb.ComplexType<Domain.Model.AuditInformation>().Property(a => a.CreatedDate).HasColumnName("Created_On");
            mb.ComplexType<Domain.Model.AuditInformation>().Property(a => a.CreatedByUserId).HasColumnName("Created_By");
            mb.Entity<Cricketer>().Map(a =>
            {
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.UserId).HasColumnName("User_Id");
                a.Property(x => x.Domain).HasColumnName("User_Dmain");
                a.Property(x => x.AuditDetails.CreatedByUserId).HasColumnName("CreatedByUserId");
                a.Property(x => x.AuditDetails.CreatedDate).HasColumnName("CreatedDate");
            })
            .HasKey(x => x.ID)
            .ToTable("Tbl_User");   //<==Again, dont ask
        }
    }
