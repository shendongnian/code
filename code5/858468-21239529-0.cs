    public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ViewState["Counter"] = 0;
                }
            }
    
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                for (int i = 0; i <= Convert.ToInt32(ViewState["Counter"]); i++)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Controls.Add(new TextBox());
                    pnlControls.Controls.Add(div);
    
                }
    
                ViewState["Counter"] = Convert.ToInt32(ViewState["Counter"]) + 1;
            }
        }
