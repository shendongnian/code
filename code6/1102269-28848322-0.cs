    var sql = new StringBuilder();
    sql.AppendLine("SELECT * FROM [ItemMaster]");
    			
    var whereClause = CheckFilter(txtArticle) + 
                      CheckFilter(txtPartnumber) + 
                      CheckFilter(txtSmn);
    
    if (!string.IsNullOrEmpty(whereClause))
    {
    	sql.AppendLine(" WHERE ");
    	sql.AppendLine(whereClause);
    }
    // using the textbox Name property as the column name
    private string CheckFilter(TextBox textbox)
    {
    	return !string.IsNullOrEmpty(textbox.Text) 
    		? string.Format(" {0} = {1} ", textbox.Name, textbox.Text) 
    		: string.Empty;
    }
