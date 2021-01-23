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
                        
                        ToolScriptManager1.RegisterPostBackControl(ImageButton1);
                    }
                }
                if (c.Controls.Count > 0)
                {
                    FindAllTextBoxes(c);
                }
            }
        }
 
    protected void ImageButton1_OnClick(object sender, EventArgs e)
        {
            
            ImageButton ImageButton1 = (ImageButton)sender;
            FormViewRow row = (FormViewRow)ImageButton1.Parent.Parent;
    
            FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload1");
    
            if (FileUpload1.HasFile)
            {
                
            }
    
    
        
        }
    
