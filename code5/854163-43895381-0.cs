       if (!IsPostBack)
        {
            Menu Menu = (Menu)Page.Master.FindControl("Menu1");
            if (Menu.Items.Count > 0)
            {
                foreach (MenuItem mi in Menu.Items)
                {
                    if (mi.Text == "Contact Us")
                    {
                        mi.Selected = true;
                    }
                }
            }
           
        }
    }
