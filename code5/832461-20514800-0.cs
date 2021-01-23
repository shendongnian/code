    public class ABC 
    {
        public int var_1;
        public int var_2;
        public int var_3;
        //... until 100
        public int var_100;
    	
    	private Dictionary<int,int> map;
    	
    	public ABC()
    	{
    		//build up the mapping
    		map = new Dictionary<int,int>();
    		map.Add(1,var_1);
    		map.Add(2,var_2);
    		map.Add(100,var_100);
    	}
    	
    	public int GetData(int id)
    	{
    		//maybe here you need to do check if the key is present
    		return map[id];
    	}
    }
