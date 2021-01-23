    using System;
    
    namespace Works4Me
    {
    	public interface ISessionFactory { }
    	public class EntityBase { }
    	public class BaseRepository<T> where T : EntityBase { }
    	
        public class FooRepository<T> : BaseRepository<T>
            where T : EntityBase
        {
            public FooRepository(ISessionFactory sessionFactory)
            {
            }
    
            public void Log(T entity)
            {
            }
        }
        
        public class Test
        {
    	    public static void Main()
    	    {
    		// your code goes here
    	    }
        }
    }
