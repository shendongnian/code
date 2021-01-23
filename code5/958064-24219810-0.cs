        string number = "1257.00";
		double value = 0.00;
		if (double.TryParse(number, out value)) 
		{
			string roundedNumber = number.Substring(0, (number.IndexOf('.') > 0 ? number.IndexOf('.') : number.Length)-1) + "0";
			if (double.TryParse(roundedNumber, out value))
			{
				Console.WriteLine(String.Format("{0:0.##}", value));
			}
			else
			{
				Console.WriteLine("Error!");
			}
		}
		else
		{
			Console.WriteLine("Error!");
		}
