	public static void Main()
	{
		int a= int.Parse(Console.ReadLine());
		int sum=0;
		
		for(int i=0 ; i<= a ;i++)
		{
			for(int j=0 ; j<i ;j++)
			{
				sum =+ (i*i);
			}
			Console.WriteLine("Number is : {0} and cube of the {0} is :{1} \n",i,sum*i);
		}
	}
