	static class StringCompareExtensions
	{
		public static bool IsLike(this string s, string s2)
		{
			int matched = 0;
		
			for (int i = 0; i < s2.Length; i++)
			{
				if (matched >= s.Length)
					return false;
					
				char c = s2[i];
				if (c == '?')
					matched++;
				else if (c == '*')
				{
					if ((i + 1) < s2.Length)
					{
						char next = s2[i + 1];
						int j = s.IndexOf(next, matched + 1);
						if (j < 0)
							return false;
						matched = j;
					}
					else break; // '*' matches rest of s
				}
				else
				{
					if (c != s[matched])
						return false;
					matched++;
				}
			}
			return (matched == s.Length);
		}
	}
