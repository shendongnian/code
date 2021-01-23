    public class Program
    {
    	public void Main()
        {
    		int[] arr = {4, 8, 9, 13, -9, 78, 5};
    		FindMinAvgMax(arr);
        }
    	
    	public void FindMinAvgMax(int[] a)
    	{
    		int len = a.Length;
    		int sum = 0;
    		int min = a[0];
    		int max = a[0];
    		int avg;
    		
    		for(int i = 0; i < len; i++)
    		{
    			sum += a[i];
    			
    			if(a[i] < min)
    				min = a[i];
    			else if(a[i] > max)
    				max = a[i];
    		}
    		
    		avg = sum /len;
    		
    		Console.WriteLine("Min: {0}", min);
    		Console.WriteLine("Max: {0}", max);
    		Console.WriteLine("Avg: {0}", avg);
    	}
    }
