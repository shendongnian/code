    public class A 
    {
       public Guid Id {get; set;}
       [ForeignKey("AccountKey")]
       public Account Account{get; set;}
       // FK-Nav property
       public Guid AccountKey{get;set;}
       public class EntityConfiguration : EntityConfigurationBase<A>
       {   
           public EntityConfiguration()
           {
               // works ;) but i can't specify the foreign key :'(
               HasOptional(x => x.Account);
            }
        }
    }
