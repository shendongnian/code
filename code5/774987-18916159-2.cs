    private static string Test(string number)
    {
    	try 
        {
    		gridview.DataSource = DBAPI.ExecuteSqlFunction(function, new string[] { CurrentSourceID });
    		gridview.CellFormatting += gridView_CellFormatting;
    	} 
        catch (Exception ex) 
        {
    		SaveAndShowLog(ex);
    	}
    }
    
    public static string GetFormattedNumber(string number)
    {
    	try
        {
    		return string.Format("{0:N0}", Int64.Parse(number));
    	} 
        catch (Exception ex) 
        {
    		SaveAndShowLog(ex);
    		return number;
    	}
    }
    
    private static void gridView_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
    	if (e.ColumnIndex == 2)
        {
    		object val = gridview.Rows[e.RowIndex].Cells[2].Value;
    		if ((val != null) && !object.ReferenceEquals(val, DBNull.Value))
            {
    			e.Value = GetFormattedNumber(val.ToString().Replace(",", ""));
    			e.FormattingApplied = true;
    		}
    
    	}
    }
