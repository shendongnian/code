    class Program
	{
		private static void Main(string[] args)
		{
			int x = 100, y = 4;
			int count = 0;
			string[,] MyArray = new string[x, y];
			for(int i = 0; i < x; i++)
			{
				for(int j = 0; j < y; j++)
				{
					MyArray[i, j] = (++count).ToString();
					//Console.WriteLine(MyArray[i, j]);
				}
			}
			bool found = false;
			bool finish = false;
			Console.WriteLine("Enter a number to find:");
			int mynumber = int.Parse(Console.ReadLine());
			for(int i = 0; i < x; i++)
			{
				for(int j = 0; j < y; j++)
				{
					if(MyArray[i, j].Equals(mynumber))
					{
						found = true;
						break;
					}
					else
					{
						finish = true;
						break;
					}
				}
			}
			if(found)
			{
				Console.WriteLine("The Number searched is {0}", mynumber);
			}
			else if(finish)
			{
				Console.WriteLine("End of search ");
			}
			Console.ReadLine();
		}
	}
