    ...
    // set temporary the ID as a text
    col.Text = item.OID.ToString();
    YourGrid.ItemDataBound += OnYourGridItemBound;
    ...
    private static void OnYourGridItemBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
    	GridDataItem dataBoundItem = e.Item as GridDataItem;
    	if (dataBoundItem != null)
    	{
    		foreach (TableCell cell in dataBoundItem.Cells)
    		{
    			if (cell.Controls.Count > 0)
    			{
    				var link = cell.Controls[0] as HyperLink;
    				if (link != null)
    				{
    					var dataItem = dataBoundItem.DataItem as MyClass;
                        var id = link.Text;
    					link.Text =                                     
                           dataItem.AnotherObject[id].Person.FormattedName;
    				}
    			}
    		}
    	}
    }
