	using System;
	using System.Text;
	namespace ConsoleApplication18
	{
		class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine("Where to search -->");
				string text = Console.ReadLine();
				string pattern = "ja"; // Probably, it is better to get it from Console as well      
				
				for (int i = 0; i < text.Length; i++)
				{
					for (int j = 0; j < pattern.Length; j++)
					{
						if (text[i+j] == pattern[j] && j == pattern.Length - 1)
							Console.WriteLine(i);
						if (text[i+j] != pattern[j]) break;
					}
				}
			}
		}
	}
