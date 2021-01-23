    public class MyContext : DbContext
    {
    	protected override void OnModelCreating(DbModelBuilder mb)
    	{
    		mb.Types<EntityBase>()
              .Configure(config => config.Ignore(x => x.SomeBaseClassPropertyToIgnore));
    	}
    }
