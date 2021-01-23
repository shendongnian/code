    public class BaseArray
    {
    	int[,] m_array = new int[5, 5];
    
    	public int this[int x, int y]
    	{
    		get { return m_array[x, y]; }
    		set { m_array[x, y] = value; }
    	}
    }
    
    public class SubArray
    {
    	BaseArray[] m_array = new BaseArray[3];
    
    	public BaseArray this[int x]
    	{
    		get { return m_array[x]; }
    		set { m_array[x] = value; }
    	}
    }
