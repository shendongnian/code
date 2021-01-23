	var sql = new StringBuilder();
	sql.AppendLine("SELECT * FROM [ItemMaster]");
			
	var whereClause = CheckFilter(txtArticle) + 
					CheckFilter(txtPartnumber) + 
					CheckFilter(txtSmn);
    
	whereClause = whereClause.Substring(0, whereClause.Length - 5);
	if (!string.IsNullOrEmpty(whereClause.Trim())
	{
		sql.AppendLine(" WHERE ");
		sql.AppendLine(whereClause);
	}
	// using the textbox Name property as the column name
	private string CheckFilter(TextBox textbox)
	{
		return !string.IsNullOrEmpty(textbox.Text) 
			? string.Format(" {0} = {1} AND ", textbox.Name, textbox.Text) 
			: string.Empty;
	}
