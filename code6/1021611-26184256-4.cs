    public class Example
    {
    	public void Test()
    	{
    		var t1 = new List<Table1>();
    		var t2 = new List<Table2>();
    		var t3 = new List<Table3>();
    		var filter = "hello";
    		Func<string, bool> filterFunc = (x) => x.StartsWith(filter);
        
        	var rpt1 = t1.Where(x => filterFunc(x.Name));
    		var rpt2 = t2.Where(x => filterFunc(x.Name));
    		var rpt3 = t3.Where(x => filterFunc(x.Name));
    
    	}
    }
