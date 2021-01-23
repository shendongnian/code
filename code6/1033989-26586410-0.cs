    class Sp :  EntityTypeConfiguration<Sp>
    {
       public Sp()
       {
          ToTable("Sp", "dbo");
          HasKey(x => x.Id);
    
          Property(x => x.Id).HasColumnName("ID");
          Property(x => x.FileId).HasColumnName("FILE_ID");
    
          //the location of the error
          HasRequired(d => d.File)
            .WithMany(d => d.Sps)
            .HasForeingKey(d => d.FileId)
            .WillCascadeOnDelete(false);
        }
     }
