    interface IEntity {
    	public int Id { get; }
    	public string Name { get; }
    }
    
    class Building : IEntity {
    	public int Id { get; private set; }
    	public string Name { get { return this.Description; } }
    }
