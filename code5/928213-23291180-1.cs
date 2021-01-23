    public partial class MenuButton : System.Web.UI.UserControl
    {
        public String Url { get; set; }
        public string Description { get; set; }
        public List<MenuItem> Children { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Children != null)
            {
                foreach (var menuItem in Children)
                {
                    // Create a button from the ascx file
                    var but = (MenuButton)LoadControl("/MenuItems/MenuButton.ascx");
                    // bind!
                    but.Children = menuItem.Children;
                    but.Description = menuItem.Description;
                    but.Url = menuItem.Url;
                        
                    if (ul1 != null)
                    {
                        // add our button
                        ul1.Controls.Add(but);
                    }
                }
            }
        }
    }
