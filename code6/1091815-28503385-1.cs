    public interface IObject
    {
         IObject GetSomeObject();
    }
    
    public class ObjectClass : IObject
    {
        public ObjectClass GetSomeObject()
        {
        	return this;
        }
    	
    	IObject IObject.GetSomeObject()
    	{
    		return this;
    	}
    }
