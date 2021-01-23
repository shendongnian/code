		[TestCase( 1, 1, "A1" )]
		[TestCase( 2, 26, "Z2" )]
		[TestCase( 2, 26 + 26, "AZ2" )]
		[TestCase( 2, 26 + 26 + 26, "AAZ2" )]
		[TestCase( 2, 26 + 26 + 26 + 26, "AAAZ2" )]
		public void CanGetCorrectCellReference( int row, int column, string expected )
			=> GetCellReference( (uint)row, (uint)column ).Value.ShouldEqual( expected );
		public static StringValue GetCellReference( uint row, uint column ) =>
			new StringValue($"{GetColumnName("",column)}{row}");
		static string GetColumnName( string prefix, uint column ) => 
			column < 27 ? $"{prefix}{(char) ( 64 + column )}" : 
			GetColumnName( GetColumnName( prefix, column % 26 + 1 ), column - 26 );
