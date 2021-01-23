    public class MyMenuItem
    {
        public bool ShowWhenNotLoggedIn { get; set; }
        public System.Web.UI.WebControls.MenuItem MenuItem { get; set; }
    }
    List<MyMenuItem> MyMenuItems = new List<MyMenuItem>(); //Create all your menu items and put them in here before running the menthod below
    void CreateMyMenu(bool IsUserLoggedIn)
    {
        MyMenu.Items.Clear();
        foreach (MyMenuItem item in MyMenuItems)
        {
            if (item.ShowWhenNotLoggedIn || IsUserLoggedIn)
                MyMenu.Items.Add(item.MenuItem);
        }
    }
