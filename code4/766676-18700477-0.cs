	void Main()
	{
	
		string line1 = "[ACR]";
		string line2 = "53: Inverse output =0.3//commentary";
		
		var a = Regex.Match(line1,@"^\[(.*)\]").Groups;
		var b = Regex.Match(line2,@"^(\d\d):\s*(.*)\s*=(.*)//(.*)").Groups;
		
		string sectionName = a[1].Value;
		
		string number = b[1].Value;
		string setting = b[2].Value;
		string value = b[3].Value;
		string comment = b[4].Value;
	
	}
	
