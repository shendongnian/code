    /// <summary>
    /// Returns the MenuItem in this Menu that has the specified Value (case sensitive)
    /// </summary>
    /// <param name="menu"></param>
    /// <param name="ItemValue"></param>
    /// <returns></returns>
    public static System.Web.UI.WebControls.MenuItem GetMenuItemByValue(this System.Web.UI.WebControls.Menu menu, string ItemValue)
    	{
    	foreach (System.Web.UI.WebControls.MenuItem item in menu.Items)
    		{
    		if (item.Value == ItemValue)
    			{
    			return item;
    			}
    		}
    	return null;
    	}
