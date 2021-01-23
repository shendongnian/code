         DataTable table = new DataTable();
         table.Columns.Add( "fraction", typeof( string ) );
         table.Rows.Add( "1/2" );
         table.Rows.Add( "5/8" );
         table.Rows.Add( "1/3" );
         int numerator = 0;
         int denominator = 0;
         foreach ( DataRow row in table.Rows )
         {
            string[] split = row[ 0 ].ToString().Split( '/' );
            numerator += int.Parse( split[ 0 ] );
            denominator += int.Parse( split[ 1 ] );
         }
         MessageBox.Show( numerator + "/" + denominator );
