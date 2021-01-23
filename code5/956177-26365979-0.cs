    public class RavenEventStorage : IEventStorage
    {
    	private IDocumentStore store;
    
    	public RavenEventStorage(IDocumentStore store)
    	{
    		this.store = store;
    	}
    
    	public IEnumerable<Event> GetEvents(Guid aggregateId)
    	{
    		using(var session = store.OpenSession())
    		{
    			BaseMemento memento = session.Load<BaseMemento>(aggregateId);
    
                // Its null if it doesn't exist - so return an empty array
      			if(memento==null)
	       			return new Event[0];
    			return memento.Events.AsEnumerable();
    		}
    	}
    
    	public void Save(AggregateRoot aggregate)
    	{
    		using(var session = store.OpenSession())
    		{
    			session.Store(aggregate);
    			session.SaveChanges();
    		}
    	}
    
    	public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
    	{
    		using(var session = store.OpenSession())
    		{
    			return session.Load<T>(aggregateId);
    		}
    	}
    
    	public void SaveMemento(BaseMemento memento)
    	{
    		using(var session = store.OpenSession())
    		{
    			session.Store(memento);
    			session.SaveChanges();
    		}
    	}
    }
