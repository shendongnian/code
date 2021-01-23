	class Version
	{
		public int Major {get; private set;}
		public string Minor {get; private set;}
		
		public Version(string s)
		{
			// omitted error checking for brevity
            // assuming a single letter of always the same case
			var sa = s.Split('.');
			Major = int.Parse(sa[0]);
			Minor = sa[1];
		}
		
		public static bool operator <(Version one, Version another)
		{
			if (one.Major == another.Major)
				return one.Minor.CompareTo(another.Minor) < 0;
			return one.Major< another.Major;
		}
		
		public static bool operator >(Version one, Version another)
		{
			return !(one < another);
		}
		
		public static bool operator ==(Version one, Version another)
		{
			return one.Major == another.Major && one.Minor == another.Minor;
		}
		
		public static bool operator !=(Version one, Version another)
		{
			return !(one == another);
		}
		
		public static bool operator >=(Version one, Version another)
		{
			return (one > another || one == another);
		}
		
		public static bool operator <=(Version one, Version another)
		{
			return (one < another || one == another);
		}
	}
