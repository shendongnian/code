    protected void Page_Load(object sender, EventArgs e)
    {
        Menu Menu = (Menu)Page.Master.FindControl("NavigationMenuAdmin");
       Menu.MenuItemClick +=  new EventHandler((s, e) => Menu_MenuItemClick(s, e, Menu));
    }
    void Menu_MenuItemClick(object sender, MenuEventArgs Events, Menu m)
    {
        MenuItem selectedItem = m.SelectedItem;
        Response.Write("Selected Item is: " + m.SelectedItem.Text + ".");
    }
