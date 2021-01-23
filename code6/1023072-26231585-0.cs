    public class Repository
    {
        IRepository action = null;
        public Repository(IRepository concreteImplementation)
	    {
            this.action = concreteImplementation;
	    }
        public void Create<T>(T obj)
        {
            action.Create(obj);
        }
    }
