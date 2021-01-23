    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FormView ProductsFormView = (FormView)EditProduct1.FindControl("ProductsFormView");
    
                FindAllTextBoxes(ProductsFormView);
               
                
            }
        }
 
    private void FindAllTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString() == "System.Web.UI.WebControls.ImageButton")
                {
                    ImageButton ImageButton1 = (ImageButton)c.FindControl("ImageButton1");
                    if (ImageButton1 != null)
                    {
                        ToolScriptManager1.RegisterAsyncPostBackControl(ImageButton1);
                    }
                }
                if (c.Controls.Count > 0)
                {
                    FindAllTextBoxes(c);
                }
            }
        }
