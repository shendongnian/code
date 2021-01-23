    public void Main(...)
    {
	    Try 
	    {
            int[] myArray = { -2, 5, -1, 9, -6, 23, 67, 1, -8, 7, -3, 90 };
		    int index = Convert.ToInt32(Console.ReadLine())
		    int newValue = Convert.ToInt32(Console.ReadLine())
		    ChangeArray(myArray,index, newValue);
	    }
	    Catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }
	
    static void ChangeArray(int[] array, int index, int newValue )
		{
			if (array.Length >= index || index < 0)
			{
				Console.WriteLine("\n=====No change========\n");
				return;
			}
				
			Console.WriteLine("\n=====Old values========\n");
			for (int i = 0; i < array.Length; i++)
				Console.Write("{0}", array[i]);
			array[index] = newValue;
			
			Console.WriteLine("\n\n======New values=======\n");
			for (int i = 0; i < array.Length; i++)
				Console.Write("{0}", array[i]);
		}
