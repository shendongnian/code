    string col = ddlColumn.SelectedValue.Text;	
	string selColName = "new(" + col + ")";
	var q = dbContext.tbl_Batch.Select(selColName);
	List<string> myList = new List<string>();
	foreach (var colItem in q)
	{
		if (item != null)
		{
			
			Type type = item.GetType();
			PropertyInfo pInfo = type.GetProperty(col);
			var myValue = pInfo.GetValue(item, null);
			myList.Add(myValue.ToString());
		}
	}
	myList = myList.Select(x => x).Distinct().ToList();
	ddlData.DataSource = myList;
	ddlData.DataBind();
	
