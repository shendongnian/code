    void Main()
    {
    	List<string> sourceList = new List<string> {"1", "2","3", "qwert","4", "5","6", "7","asdf", "9","100", "22"};
        //Dump is a LinqPad only method. Please ignore
    	sourceList.ConvertToInt().Dump();
    }
    
    static public class HelperMethods
    {
    	static public List<int> ConvertToInt(this List<string> stringList)
    	{
            int x = 0;
    	    var intList = stringList.Where(str => int.TryParse(str, out x))
    		                        .Select (str => x)
    								.ToList();
    	    return intList;
    		
    	}
    }
