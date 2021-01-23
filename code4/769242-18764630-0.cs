    interface IDatabaseObjectFactory
    {
    	IDatabaseObject Create(DatabaseObjectData data);
    }
    
    class DatabaseObjectFactory : IDatabaseObjectFactory
    {
    	public IDatabaseObject Create(DatabaseObjectData data)
    	{
    		return new DatabaseObject {DbObjectData = data };
    	}
    }
    
    class SomePersistenceClass
    {
    	readonly IDatabaseObjectFactory _factory;
    
    	public SomePersistenceClass()
    	{
    		_factory = new DatabaseObjectFactory();
    	}
    
    	public SomePersistenceClass(IDatabaseObjectFactory factory)
    	{
    		_factory = factory;
    	}
    
        public void Persist(object value, string type) { /* ... */ }
        private void PersistNumeric(int number) { /* ... */ }
        private void PersistImpl(IDatabaseObject dbObject) { /* ... */ }
    }
    
