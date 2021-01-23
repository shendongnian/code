    protected void Page_Load(object sender, EventArgs e)
    		{
    		if (!IsUserAnAdmin(HttpContext.Current.User.Identity.Name))
    			{
    			MenuItem removeitem = NavigationMenu.GetMenuItemByValue("AdminOnly");
    			NavigationMenu.Items.Remove(removeitem);
    			}
    		}
