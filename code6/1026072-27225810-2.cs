	// this property is required to work with "AllowMultiple = true" ref David Ebbo
	// As implemented, this identifier is merely the Type of the attribute. However, 
	// it is intended that the unique identifier be used to identify two 
	// attributes of the same type.
	public override object TypeId { get { return this; } }
	public String ColumnName { get; set; }
	public Object ValueWhenTrue { get; set; }
	public FilterByAttribute(String columnName, Object valueWhenTrue)
	{
		ColumnName = columnName;
		ValueWhenTrue = valueWhenTrue;
	}
