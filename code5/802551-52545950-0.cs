	public static T ToObject<T>( this DataRow dataRow )
		 where T : new() {
		T item = new T();
		foreach( DataColumn column in dataRow.Table.Columns ) {
			if( dataRow[column] != DBNull.Value ) {
				PropertyInfo prop = item.GetType().GetProperty( column.ColumnName );
				if( prop != null ) {
					object result = Convert.ChangeType( dataRow[column], prop.PropertyType );
					prop.SetValue( item, result, null );
					continue;
				}
				else {
					FieldInfo fld = item.GetType().GetField( column.ColumnName );
					if( fld != null ) {
						object result = Convert.ChangeType( dataRow[column], fld.FieldType );
						fld.SetValue( item, result );
					}
				}
			}
		}
		return item;
	}
