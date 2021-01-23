    public partial class WebForm3: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MyCode
        }
        private void AddNewRowToGrid()
        {
            Flag = true;
        }
        
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        
        protected void btn3_Click(object sender, EventArgs e)
        {
            if (Flag == true)
            {
            }
        }
        private bool Flag
        {
            get
            {
                bool? flag = ViewState["flag"] as bool?;
                return flag.HasValue ? flag.Value : false;
            }
            set
            {
                ViewState["flag"] = value;
            }
        }
    }
