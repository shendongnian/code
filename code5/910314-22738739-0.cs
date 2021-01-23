   		int GetCardinal(string s1, string s2)
		{
			char []separators = new char[] { ' ', '\t' };
			return s1.Split(separators, StringSplitOptions.RemoveEmptyEntries).Intersect(s2.Split(separators, StringSplitOptions.RemoveEmptyEntries)).Count();
		}
