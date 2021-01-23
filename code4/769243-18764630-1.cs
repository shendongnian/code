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
        private void PersistImpl(IDatabaseObject dbObject) { /* ... */ }
        private void PersistNumeric(int number)
        {
            //Some Calculations and Creation of DBObject
            number++;
            var dbObject = _factory.Create(new DatabaseObjectData {Number = number, Creator = "John Doe"});
            PersistImpl(dbObject);
        }
    }
    
