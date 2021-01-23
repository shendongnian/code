    class AGGREGATIONSConfiguration : EntityTypeConfiguration<AGGREGATIONS>
    {
    	public AGGREGATIONSConfiguration()
    	{
    		HasKey(ag => ag.CODE);
    
    		Property(ag => ag.CODE)
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    		Property(ag => ag.CODE)
    			.HasMaxLength(20)
    			.IsRequired();
    
    		Property(ag => ag.CREATED)
    			.HasMaxLength(50)
    			.IsOptional();
    
    		HasRequired(ag => ag.Code)
    			.WithOptional(c => c.Aggregation)
    			.WillCascadeOnDelete(false);
    	}
    }
    class AGGREGATION_CHILDSConfiguration : EntityTypeConfiguration<AGGREGATION_CHILDS>
    {
    	public AGGREGATION_CHILDSConfiguration()
    	{
    		HasKey(ag_ch => ag_ch.CODE);
    
    		Property(ag_ch => ag_ch.CODE)
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    		Property(ag_ch => ag_ch.CODE)
    			.HasMaxLength(20)
    			.IsRequired();
    
    		Property(ag_ch => ag_ch.PARENT_CODE)
    			.HasMaxLength(20)
    			.IsRequired();
    
    		HasRequired(ag_ch => ag_ch.Aggregation)
    			.WithMany(ag => ag.AggregationChilds)
    			.HasForeignKey(ag_ch => ag_ch.PARENT_CODE);
    
    		HasRequired(ag_ch => ag_ch.Code)
    			.WithOptional(c => c.AggregationChild)
    			.WillCascadeOnDelete(false);
    	}
    }
