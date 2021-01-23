    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        string role = Session["Roles"].ToString();
        string AdminRole = ConfigurationManager.AppSettings["AdminRole"];
        string StaffRole = ConfigurationManager.AppSettings["StaffRole"];
        string StudentRole = ConfigurationManager.AppSettings["StudentRole"];
    
        if (role == StaffRole)
        {
            if (e.Item.Text == "Project Choices" ||
                e.Item.Text == "Staff Records" ||
                e.Item.Text == "Student Records")
            {
                Menu1.Items.Remove(e.Item);
            }    
        }
    }
