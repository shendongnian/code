    public partial class WebForm1 : System.Web.UI.Page
        {
            private DataTable _Source;
    
            public WebForm1()
            {
            }
    
            private void ResetData()
            {
                _Source = new DataTable();
                _Source.Columns.Add("Name", typeof(string));
                _Source.Columns.Add("Number", typeof(string));
                Random rn = new Random();
                for (int t = 0; t < 100; t++)
                {
                    _Source.Rows.Add(rn.Next(1, 10).ToString(), rn.Next(1, 10).ToString());
                }
    
                Session["data"] = _Source;
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ResetData();
                    GridView1.DataBind();
                }
                _Source = Session["data"] as DataTable;
            }
    
            protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
            {
    
            }
    
            protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                ((DataTable)Session["data"]).Rows.RemoveAt(e.RowIndex);
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                ResetData();
                GridView1.DataBind();
            }
    
            protected void GridView1_DataBinding(object sender, EventArgs e)
            {
    
                GridView1.DataSource = _Source;
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                var button = sender as Button;
                button.Enabled = false;
                var hidden = button.Parent.FindControl("HiddenField2") as HiddenField;
                var name = hidden.Value;
                DeletForName(name);
            }
    
            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
    
            }
            private void DeletForName(string name)
            {
                
                foreach (DataRow row in _Source.Rows)
                    if (row["Name"].Equals(name))
                    {
                        _Source.Rows.Remove(row);
                        break;
                    }
            }
        }
