    public  void SpillInt(){
   			int n = 7658;
			
			int remainder = 0;
			int divider = 10;
			IList<int> result = new List<int>();
			do
			{
			           remainder = n % divider;
				result.Add(remainder);
				n = (n - remainder) / 10;
			}
			while (n > 0);
            			for (int i = result.Count; i >= 0; i++)
			{
				Console.Write(result[i]);
			}
    }
