    using System;
    using System.Web.UI.WebControls;
    public class MyDataGrid : DataGrid
    {
    	protected override void OnItemDataBound(DataGridItemEventArgs e)
    	{
    		base.OnItemDataBound(e);
    		
    		if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
    		
    		var dt = DataSource as DataTable;
    		
    		if (dt != null)
    		{		
    			for (int i=0; i < dt.Columns.Count; i++)
    			{
    				if (dt.Columns[i].DataType == typeof(string))
    				{
    					e.Item.Cells[i].Style["mso-number-format"] = @"\@";
    				}
    			}
    		}
    	}
    }
