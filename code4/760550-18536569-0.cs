    void Main()
    {
	var i = 10545;
	var t = i.ToString().PadLeft(6, '0');
	
	var d = DateTime.ParseExact(t, "HHmmss", System.Globalization.CultureInfo.InvariantCulture );
	
	Console.WriteLine(string.Format("{0:HH:mm:ss}", d));
    }
