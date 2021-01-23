    public void Page_Load(object sender, EventArgs e)
    {
        GridFilterMenu menu = RadGrid1.FilterMenu;
        int i = 0;
        while (i < menu.Items.Count)
        {
            if (menu.Items[i].Text == "IsNull")
            {
                //Upadte Text
                menu.Items[i].Text = "your_custom_string";
            }
            else if (menu.Items[i].Text == "IsEmpty")
            {
                //Rmeove menu item
                menu.Items.RemoveAt(i);
            }
    
            i++;
        }
    }
