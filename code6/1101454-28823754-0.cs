    public class Program
    {
    	private static bool IsEqual(int data1, int[] arr2, out int index)
    	{
    		bool find = false;
    		index = -1;
    		for(int i = 0; i < arr2.Length; i++)
    		{
    			if (data1 == arr2[i])
    			{
    				find = true;
    				index = i;
    				break;
    			}
    		}
    
    		return find;
    	}
    
    	public static void Main()
    	{
    		// and this is i call the function 
    		int data1 = 2;
    		int[] arr =
    		{
    		1, 2, 3, 4, 5
    		};
    
    		int index;
    		if (IsEqual(data1, arr, out index))
    		{
    			Console.WriteLine("Find in index {0}", index);
    		}
    	}
    }
