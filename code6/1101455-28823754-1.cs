    using System;
    public class Program
    {
        // this is your method
        // using an out parameter and a for loop
        // ignore the static keyword - it isn't important for the example
    	private static bool IsEqual(int data1, int[] arr2, out int index)
    	{
    		index = -1;
    		bool find = false;
    		for(int i = 0; i < arr2.Length; i++)
    		{
    			if (data1 == arr2[i])
    			{
    				find = true;
    				index = i;
    				break;
    			}
    		}
            // you don't need to return the index
            // the out parameter covers that for you
    		return find;
    	}
    
    	public static void Main()
    	{
    		// and this is i call the function 
    		int data1 = 2;
    		int[] arr = { 1, 2, 3, 4, 5 };
    
    		int index;
    		if (IsEqual(data1, arr, out index))
    		{
    			Console.WriteLine("Find in index {0}", index);
    		}
    	}
    }
