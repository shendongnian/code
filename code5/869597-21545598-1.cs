    public partial class _Default : System.Web.UI.Page
    {
    
        string Sort_Direction = "Date DESC";
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
            if (!IsPostBack)
            {
               // GetRegistrationDetails();
                ViewState["SortExpr"] = Sort_Direction;
                DataView dv = Getdata();
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
        }
    
        private DataView Getdata()
        {      
            string strSql = "SELECT * ROM TEST_Table ";
            DataSet ds = DataProvider.Connect_Select(strSql);
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = ViewState["SortExpr"].ToString();
            return dv;
        }
    
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataView dv = Getdata();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    
        protected void GridView1_OnSorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.PageIndex = 0;
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            GridView1.DataSource = Getdata();
            GridView1.DataBind();
        }
    }
