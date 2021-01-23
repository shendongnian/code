	theData = GetData();
	if (theData.Rows.Count > 0)
	{
		MyModel = new CustomModel();
		dataSetRow = theData.Rows[0];
		foreach(column in columns)
		{
			if (theData.Columns.Contains(column))
			{
				if ((!object.ReferenceEquals(dataSetRow[column], DBNull.Value)))
				{
				MyModel.GetType().InvokeMember(column,
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
				Type.DefaultBinder, MyModel, Convert.ToString(dataSetRow[column]));
					
				}
			}
		}
	}		
