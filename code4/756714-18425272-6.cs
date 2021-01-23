      public class Product{
        	public string Name {get;set;}
        	public double Price {get;set;}
        	public string UPC {get;set;}
        	public string Description {get;set;}
        	
        }
        
        public class ModelConfigurator{
        	
        	public DbModelBuilder ModelBuilder{get;set;}
        	
        	public ModelConfigurator(DbModelBuilder modelBuilder){
        		ModelBuilder = modelBuilder;
        	}
        	
        	public EntityConfigurator<TEntity> Entity<TEntity>() where TEntity : class {
        		var entity = ModelBuilder.Entity<TEntity>();
        		return new EntityConfigurator<TEntity>(entity);
        	}
        }
        
        public class EntityConfigurator<TEntity> where TEntity : class{
        	
        	public EntityTypeConfiguration<TEntity> EntityTypeConfiguration {get;set;}
        	
        	public EntityConfigurator(EntityTypeConfiguration<TEntity> entityTypeConfiguration){
        		EntityTypeConfiguration = entityTypeConfiguration;
        	}
        	
        	public EntityConfigurator<TEntity> Has(Action<EntityTypeConfiguration<TEntity>> a){
        		a(this.EntityTypeConfiguration);
        		return this;
        	}
        }
