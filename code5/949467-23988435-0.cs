    double[] temp = new double[activeSheet.Rows.Count];
	int i = 0;
	for (i = 0; i < activeSheet.Rows.Count; i++)
	{
		var item = (activeSheet.Cells[i + 1, 1] as Excel.Range).Value2;
		if (item == null)
			break;
		temp[i] = item;
	}
    ...
