    public class MyClassMap : EntityTypeConfiguration<MyClass>
    {
        public MyClassMap ()
        {
            this.ToTable("dbo.MyClass");
            
            HasKey(pc => new { pc.Object1Id, pc.Object2Id});
            HasRequired(x => x.Object1).WithMany().HasForeignKey(x => x.Object1Id);
            HasRequired(x => x.Object2).WithMany().HasForeignKey(x => x.Object2Id);
        }
    }
