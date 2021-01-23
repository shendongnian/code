    class Tollgate
    {
    	public void Check(int []numbers, int Token)
    	{
    		int i;
    		
    		//change this for to the actual logic that you need
    		//for (int numbers[i] = 0; numbers[i] < numbers.Length; numbers[i]++)
    		for (i = 0; i < numbers.Length; i++)
    		{
    			int s = numbers[i];
    			if ( Token > s)
    			{
    				Console.WriteLine("You Got To Wait");
    			}
    			else
    			{
    				//handle else logic
    				
    				//if need to stop the loop when this condition is met, insert a "break;" (condition is Token <= s)
    			}	
    			
    		}
    	}
    }
    class That
    {
    	public static void Main()
    	{
    		 int[] numbers = {1, 2, 3, 4, 5};
    		 Random rnd ;
    		 int r ;
    		 int Token ;
    		 Tollgate T ;  
    		 
    		 rnd = new Random();
    		 r = rnd.Next(numbers.Length);
    		 Token = numbers[r];
    		 T = new TollGate();  
    		 T.Check(numbers, Token); 
    	}
    }
