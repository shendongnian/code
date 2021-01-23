    public class MyDataGrid : System.Web.UI.WebControls.DataGrid
    {
    	protected override void OnItemDataBound(System.Web.UI.WebControls.DataGridItemEventArgs e)
    	{
    	    // Assumes your field is in the first column 
    		e.Item.Cells[0].Style["mso-number-format"] = @"\@";
    	}
    }
