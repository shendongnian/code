    namespace CS
    {
    	public class Test
    	{
    		public int GetNum()
    		{
    			return 5;
    		}
    
    		public void ShowArray(int num, float[] arr)
    		{
    			for (int i = 0; i < num; i++)
    			{
    				Console.WriteLine("[{0}] = {1}",i,arr[i]);
    			}
    		}
    	}
    }
