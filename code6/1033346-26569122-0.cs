    string db = Application.StartupPath + "\\Database1.accdb";
    string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db;
    OleDbConnection c = new OleDbConnection(cs);
    
    try
    {
    	c.Open();
    
    	string s = "insert into fruit (fruitname) values (@fruitname)";
    	using (OleDbCommand cmd = new OleDbCommand(s, c))
    	{
    		cmd.Parameters.AddWithValue("@fruitname", textBox1.Text.Trim());
    		cmd.ExecuteNonQuery();
    	}
    }
    catch (Exception)
    {
    	throw;
    }
    finally
    {
    	c.Close();
    }
