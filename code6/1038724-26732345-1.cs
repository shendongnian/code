    DataTable dtc = dt.Clone();
    for ( int i = 2; i < dtc.Columns.Count; ++i )
    	dtc.Columns[ i ].DataType = typeof( double );
    foreach ( DataRow row in dt.Rows )
    	dtc.ImportRow( row );
