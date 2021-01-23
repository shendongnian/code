    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "MenuItemName")
        {
            e.Item.Target = "_blank";            
        }
    }
