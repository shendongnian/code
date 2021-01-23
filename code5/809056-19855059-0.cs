    public interface IDataContainer
    {
    	object GetData{get;set;}
    }
    
    public class DataContainer<T> : IDataContainer
    {
        public T GetData { get; private set; }
    
    	object IDataContainer.GetData 
    	{
    		get { return this.GetData; }
    		set { this.GetData = (T)value; }
    	}
        
    	public DataContainer(T data)
        {
            this.GetData = data;
        }
    }
