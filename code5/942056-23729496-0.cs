    public class MenuItemInfo
    {
        public string Text { get; set; }
        public object Tag { get; set; }
        public EventHandler Handler { get; set; }
    }
    var menuItems = new List<MenuItemInfo>
    {
        new MenuItemInfo
        {
            Text = "whatever",
            Tag = whatever,
            Handler = (o, s) =>
            {
                //Do whatever
            }
        }
    };
    ToolStripMenuItem toolStripMenuItem;
    foreach (var mi in menuItems)
    {
        ToolStripMenuItem foo = new ToolStripMenuItem(mi.Text);
        foo.Click += mi.Handler;
        foo.Tag = mi.Tag;
        toolStripMenuItem.DropDownItems.Add(foo);
    }
