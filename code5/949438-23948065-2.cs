    using (var con = yourConnectionFactory.Create())
    {
        using (var cmd = new SqlCommand(con))
        {
    		var safeKey1 = OnlyLettersAndDigits(DDL1.SelectedItem.Text);
    		var safeKey2 = OnlyLettersAndDigits(DDL2.SelectedItem.Text);
    
    		cmd.CommandText = "SELECT F.Col1,F.Col2,V.COL1, col2,col3, col4 , col5, cl6 " + 
    							  " FROM TABLE1 as V , TABL2 as F WHERE V.Col1 = F.Col1 " +
    							  " AND " + safeKey1 + " >= @text1 " + 
    							  " AND " + safeKey2 + " <= @text2 ";
    			cmd.Parameters.AddWithValue("text1", T1.Text);
    			cmd.Parameters.AddWithValue("text2", T2.Text); 
    			var adapter = new SqlDataAdapter(cmd);
    
    			var data = new DataSet();
    			sql.Fill(data);
    			Session["DataforSearch_DDL"] = data.Tables[0];
        }
    }
    
    public string OnlyLettersAndDigits(string value)
    {
    	var stripped = "";
    	foreach (var ch in value)
    	{
    		if (char.IsLetterOrDigit(ch))
    			stripped += ch;
    	}
    
    	return stripped;
    }
