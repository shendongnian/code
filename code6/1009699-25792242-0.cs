        bool found = false;
		
		foreach(var code in codesList)
        {
            Regex rgx = new Regex(@"[^0-9\-\.]");
            code = rgx.Replace(code, "");
			
			double num;
			
			if(double.TryParse(code, num))
			{
                // floating point number comparison should be done against a delta,
                // adjust as needed
				if(Math.Abs(num - numberToFind) < 0.000001d)
                {
					found = true;
					break;
				}
			}	 
        }
