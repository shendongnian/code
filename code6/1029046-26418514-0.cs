    Compare(Object x, Object y)
    {
		MyItem i1 = (MyItem)x;
		MyItem i2 = (MyItem)y;
		
		if(i1.Price != i2.Price)
		{
			//sort by group
			return (i1.Price < i2.Price);
		}
		else
		{
			//sort priority within group
			return LevenshteinDistance(i1.Name,i2.Name);
		}
	}
		
	private int LevenshteinDistance(string s1, string s2)
	{
		...
	}
