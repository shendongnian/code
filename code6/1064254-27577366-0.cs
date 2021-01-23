	class Program
	{
		static void Main(string[] args)
		{
			string line = string.Empty;
			line += NumberToWords(5051);
			line += " [at] ";
			line += NumberToWords(50);
			line += " [end]";
			Console.WriteLine(line);
			Console.ReadKey();
		}
		public static string NumberToWords(int number)
		{
			var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
			if (number == 0)
			{
				return "zero";
			}
			string words = string.Empty;
			if ((number / 1000000) > 0)
			{
				words += unitsMap[(number / 1000000)];
				words += " million";
				number %= 1000000;
			}
			if ((number / 1000) > 0)
			{
				words += unitsMap[(number / 1000)];
				words += " thousand";
				number %= 1000;
			}
			if ((number / 100) > 0)
			{
				words += unitsMap[(number / 100)];
				words += " hundred";
				number %= 100;
			}
			if (number > 0)
			{
				if (words != "")
				{
					words += " and ";
				}
				if (number < 20)
				{
					words += unitsMap[number];
				}
				else
				{
					words += tensMap[number / 10];
					if ((number % 10) > 0)
					{
						words += "-" + unitsMap[number % 10];
					}
				}
			}
			return words;
		}
	}
