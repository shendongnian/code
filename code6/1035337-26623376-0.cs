    var menu = Page.Master.FindControl("Menu1") as Menu;
    if(UserStatus != "Admin")
    {
     Menu1.Items.Remove(Menu1.FindItem("INSPECTION"));
     Menu1.Items.Remove(Menu1.FindItem("WORK"));
    }
