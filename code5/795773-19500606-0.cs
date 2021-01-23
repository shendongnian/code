	public static string ReduceSpaces( string input )
	{
		char[] a = input.ToCharArray();
		int placeComma = 0, placeOther = 0;
		bool inQuotes = false;
		bool followedComma = true;
		foreach( char c in a ) {
			inQuotes ^= (c == '\"');
			if (c == ' ') {
				if (!followedComma)
					a[placeOther++] = c;
			}
			else if (c == ',') {
				a[placeComma++] = c;
				placeOther = placeComma;
				followedComma = true;
			}
			else {
				a[placeOther++] = c;
				placeComma = placeOther;
				followedComma = false;
			}
		}
		return new String(a, 0, placeComma);
	}
