    private bool IsEditing(Microsoft.Office.Interop.Excel.Application excelApp)
    {
    	if (excelApp.Interactive)
    	{
    		try
    		{
    			excelApp.Interactive = false;
    			excelApp.Interactive = true;
    		}
    		catch (Exception)
    		{
    			MessageBox.Show("Please stop cell editing before you continue.");
    			return true;
    		}
    	}
    	return false;
    }
