    public CarMap()
    {
        ToTable("CARS");
        HasKey(t => t.Id);
        Property(t => t.Id).HasColumnName("CAR_ID");
        HasOptional(x => x.Engine).WithMany().HasForeignKey(x=>x.EngineId);
    }
