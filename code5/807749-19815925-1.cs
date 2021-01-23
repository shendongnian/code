    public class A 
    {
       public Guid Id {get; set;}
       
       public Account Account{get; set;}
       // FK-Nav property
       public Guid AccountKey{get;set;}
       public class EntityConfiguration : EntityConfigurationBase<A>
       {   
           public EntityConfiguration()
           {
     
               HasOptional(x => x.Account).HasMany().HasForeignKey(x=>x.AccountKey);
            }
        }
    }
