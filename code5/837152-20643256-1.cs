    protected void Page_Load(object sender, EventArgs e)
    		{
    		string username = HttpContext.Current.User.Identity.Name;
    		Person p = Person.GetPersonFromUsername(username);
    		LoginLbl.Text = username;
    		if (OraclePasswords.IsUserAnAdmin(p.Initials))
    			{
    			}
    		else
    			{
    			MenuItem removeitem = NavigationMenu.GetMenuItemByValue("AdminOnly");
    			NavigationMenu.Items.Remove(removeitem);
    			}
    		}
