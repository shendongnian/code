		[TestCase( 1, 0, "A1" )]
		[TestCase( 2, 25, "Z2" )]
		[TestCase( 2, 38, "AM2" )]
		[TestCase( 2, (26 * 4) + 1, "DB2" )]
		[TestCase( 2, (26 * 26 * 26 * 18) + (26 * 26 * 1) + (26 * 26 * 1) + ( 26 * 1 ) + 2, "RBAC2" )]
		public void CanGetCorrectCellReference( int row, int column, string expected )
			=> GetCellReference( (uint)row, (uint)column ).Value.ShouldEqual( expected );
		public static StringValue GetCellReference( uint row, uint column ) =>
			new StringValue($"{GetColumnName("",column)}{row}");
		static string GetColumnName( string prefix, uint column ) => 
			column < 26 ? $"{prefix}{(char)( 65 + column)}" : 
			GetColumnName( GetColumnName( prefix, ( column - column % 26 ) / 26 - 1 ), column % 26 );
