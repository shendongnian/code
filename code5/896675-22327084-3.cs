    using Domain.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    namespace Data.EntityConfigurations
    {
    	public class RegionalSalesManagerConfiguration : EntityTypeConfiguration<RegionalSalesManager>
    	{
    		public RegionalSalesManagerConfiguration()
    		{
    			//Table
    			ToTable("RegionalSalesManagers");
    
    			//Primary key
    			HasKey(e => e.Id);
    
    			//Properties
    			Property(e => e.Id).HasColumnName("RegionalSalesManagerId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    		}
    	}
    }
