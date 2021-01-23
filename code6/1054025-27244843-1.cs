	// now add the rows
	for (int i = 0; i < _intMaxNoOfRows; i++)
	{
		// column 1 = Nationality
		if (!string.IsNullOrWhiteSpace(strArrayList[i, 1]))
		{
			var dataRow = _dTable.NewRow();
			for (int j = 0; j < _maxJ; j++)
				dataRow[j] = strArrayList[i, j];
				
			_dTable.Rows.Add(dataRow);  
		}
	}
