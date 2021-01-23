    public class Repository
    {
        IRepository action = null;
        public Repository(IRepository concreteImplementation, Type respositoryType)
	    {
            this.action = concreteImplementation;
            expectedType=repositoryType;
	    }
        public void Create(Type type, Object obj)
        {
            if(type==expected && obj.GetType()==type)
            {
                action.Create(obj);
            }
        }
    }
