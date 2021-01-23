    public static string FormaterChainePascalOuMixte(String chaine)
		{
			if (String.IsNullOrEmpty(chaine))
				return null;
			char[] charArray = chaine.ToCharArray();
			for (int i = 0; i < charArray.Length; i++)
			{
				char xxx = char.ToUpper(charArray[i]);
				if (i != 0 && charArray[i] == xxx)
				{
					charArray[0] = char.ToLower(xxx);
				}
			}
			return charArray.ToString();
		}
