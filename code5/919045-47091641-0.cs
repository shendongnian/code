    public class Program 
     {
	   public static void Main()
	    {
	 	 int[] arr1 = new int[]{1,3,3,5,5,4,1,2,3,4,5,5,5};
			
		 List<int> listArr1 = arr1.ToList();
		
		 Dictionary<int,int> dict1 = new Dictionary<int,int>();
		
		 foreach(int i in listArr1)
	    	{
			  if(dict1.ContainsKey(i))
			    {
				int value  = dict1[i];
				value++;
				dict1[i]= value;
			    }
			  else
			  {
			   dict1.Add(i,1);
			  }
		  }
		
	 	for(int x =0 ; x < dict1.Count();x++)
		{
		
		Console.WriteLine("Value {0} is repeated {1} times", dict1.Keys.ElementAt(x),dict1[dict1.Keys.ElementAt(x)]);
						  
		}
	}
}
