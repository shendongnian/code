    namespace PROJECT.CustomControls.Default
    {
        public partial class YearsOfService : System.Web.UI.UserControl
        {
            public List<Years_Of_Service> lyos { get; set; }
            public Years_Of_Service y_o_s { get; set; }
    
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    ApplyData();
                }
            }
    
            private void ApplyData()
            {
                salaryGridView.DataSource = lyos;
                salaryGridView.DataBind();
    
                if (y_o_s.TotalService.ToString() != null)
                {
                    creditSalLabel.Text = y_o_s.TotalService.ToString();
                }
                else
                {
                    creditSalLabel.Text = String.Empty;
                }
    
                if (y_o_s.PurchasedorReinstatedService.ToString() != null)
                {
                    purchaseCreditLabel.Text = y_o_s.PurchasedorReinstatedService.ToString();
                }
                else
                {
                    purchaseCreditLabel.Text = String.Empty;
                }
            }
        }
    }
