	string price = "1,234.56";
	decimal value = 0;
	var allowedStyles = (NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands);
	if (Decimal.TryParse(price, allowedStyles, CultureInfo.GetCultureInfo("DE-de"), out value))
	{
  		Console.Write("Danke!");
	}
	else if (Decimal.TryParse(price, allowedStyles, CultureInfo.GetCultureInfo("EN-us"), out value))
	{
	    Console.Write("Thank you!");
	}
	else
	{
	    throw new InvalidFormatException();
	}
