    public EngineMap()
    {
        ToTable("ENGINES");
        HasKey(t => t.Id);
        Property(t => t.Id).HasColumnName("ENGINE_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);   
    } 
