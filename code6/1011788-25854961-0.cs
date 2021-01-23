    class Map<T>
    {
    	Dictionary<int, Dictionary<int, T>> map = 
             new Dictionary<int, Dictionary<int, T>>();
    	public T this[int row,int column]
    	{
    		get { 
    			Dictionary<int, T> rowDic;
    			if(!map.TryGetValue(row,out rowDic))
    			{
    				return default(T);
    			}
    			T val;
    			if(!rowDic.TryGetValue(column, out val))
    			{
    				return default(T);
    			}
    			return val;
    		}
    		set {
    			Dictionary<int, T> rowDic;
    			if(!map.TryGetValue(row,out rowDic))
    			{
    				map[row] = new Dictionary<int, T>();
    			}
    			map[row][column] = value;
    		}
    	}
    }
