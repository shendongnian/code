    private static string UnicodeToChar( string hex ) {
		int code=int.Parse( hex, System.Globalization.NumberStyles.HexNumber );
		string unicodeString=char.ConvertFromUtf32( code );
		return unicodeString;
	}
