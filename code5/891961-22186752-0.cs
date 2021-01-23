    namespace VirtualizingDataTest
    {
      public class VirtualizedDataSource : IList
      {	
    	public object this[int index]
        {
          get
          {
            string text = "Requesting\t" + index;
            
            Debug.WriteLine(text);
            return "Item " + index;
          }
          set
          {
            throw new NotImplementedException();
          }
        }
    	
    	public DataItem GetData(object parameter)
    	{
    		return new DataItem();
    	}
    }
