    string tmpDate = "Friday, 27th September 2013";
		
    string[] splitDate = tmpDate.Split(new Char[] {' '});
    splitDate[1] = splitDate[1].Substring(0, splitDate[1].Length-2);
    string tmpDatewithoutStNdTh = String.Join(" ", splitDate);
	
    try{
        string closingDate = Convert.ToDateTime(tmpDatewithoutStNdTh).ToString("yyyy-MM-dd");
        Console.WriteLine(closingDate.ToString());
    }
    catch(System.FormatException)
    {
        Console.WriteLine("The provided date does not exist.");
    }
