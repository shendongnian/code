    public class Program
    {
    	public void Main()
        {
    		int[] arr = {4, 8, 9, 13, -9, 78, 5};
    		FindMinAvgMax(arr);
        }
    	
    	public void FindMinAvgMax(int[] n)
    	{
    		int len = n.Length;
    		int sum = 0;
    		int min = n[0];
    		int max = n[0];
    		int avg;
    		
    		for(int i = 0; i < len; i++)
    		{
    			sum += n[i];
    			
    			if(n[i] < min)
    				min = n[i];
    			else if(n[i] > max)
    				max = n[i];
    		}
    		
    		avg = sum /len;
    		
    		Console.WriteLine("Min: {0}", min);
    		Console.WriteLine("Max: {0}", max);
    		Console.WriteLine("Avg: {0}", avg);
    	}
    }
