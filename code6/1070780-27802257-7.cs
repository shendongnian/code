    public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Init(object sender, EventArgs e)
            {
                DropDownList ddl_1 = new DropDownList();
                ddl_1.ID = "ddl_1";
                ddl_1.AutoPostBack = true;
                ddl_1.EnableViewState = true;
                ddl_1.SelectedIndexChanged += new EventHandler(ddl_IndexChanged);
                this.mp_1.Controls.Add(ddl_1); 
            }
    
            private void ddl_IndexChanged(object sender, EventArgs e)
            {
                Response.Write("dsfsdf");
            }           
            
            // add entries in page load method not in init method
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    DropDownList ddl_1 = (DropDownList)Page.FindControl("ddl_1");
                    if (ddl_1 != null)
                    {
                        List<ListItem> items = new List<ListItem>();
                        items.Add(new ListItem("Item 2", "Value 2"));
                        items.Add(new ListItem("Item 1", "Value 1"));
                        items.Add(new ListItem("Item 3", "Value 3"));
                        ddl_1.Items.AddRange(items.ToArray());
                    }                
                }               
            }
        }
