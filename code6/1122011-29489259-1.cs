    namespace MyProject.Data.SqlServer.Configurations
    {
    	class AGGREGATION_CHILDSConfiguration : EntityTypeConfiguration<AGGREGATION_CHILDS>
    	{
    		public AGGREGATION_CHILDSConfiguration()
    		{
    			HasKey(ag_ch => ag_ch.CHILD_CODE);
    
    			Property(ag_ch => ag_ch.CHILD_CODE)
    				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    			Property(ag_ch => ag_ch.CHILD_CODE)
    				.HasMaxLength(20)
    				.IsRequired()
    				.HasColumnName("CODE");
    
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
    }
