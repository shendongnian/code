    public String Base12Value(int base10)
	{
		String retVal = "";
		while (base10 > 0)
		{
			//Grab the mod of the value, store the remainder as we build up.
			retVal = (base10 % 12).ToString() + retVal;
			//remove the remainder, divide by 12
			base10 = (base10 - (base10 % 12)/12);
		}
		return retVal;
	}
	public int Base10Value(String base12)
	{
		int retVal = 0;
		for (int i = 1; i <= base12.Length; i++)
		{
			int tmpVal = 0;
			char chr = base12[base12.Length-i];
			//Grab out the special chars;
			if (chr == 'X')
			{
				tmpVal = 10;
			} else if (chr == 'E')
			{
				tmpVal = 11;
			}
			else
			{
				tmpVal = int.Parse(chr.ToString());
			}
			//Times it by the location base.
			retVal += tmpVal * (10 ^ (i - 1));
			
		}
		return retVal;
	}
