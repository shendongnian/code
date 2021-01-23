    // Include external files here
    // CustomControl variable can equal something like "home.ascx"
    UserControl uc = (UserControl)Page.LoadControl("~/pages/" + CustomControl);
    // PageCustomControl can be a Panel or PlaceHolder
    PageCustomControl.Controls.Add(uc);
