    public partial class Forum : System.Web.UI.Page
    {
    
        protected void Page_Init(object source, System.EventArgs e)
        {
    
    
    
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        private void NewMethod()
        {
            DataTable dt = new DataTable();
    
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Custom1", typeof(string));
    
            dt.Rows.Add(1, "name1", "custom1");
            dt.Rows.Add(2, "name2", "custom2");
            dt.Rows.Add(3, "name3", "Radgrid1_" + DateTime.Now.ToString());
    
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }
    
        private void NewMethod2()
        {
            DataTable dt = new DataTable();
    
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Custom1", typeof(string));
    
            dt.Rows.Add(1, "name1", "custom1");
            dt.Rows.Add(2, "name2", "custom2");
            dt.Rows.Add(3, "name3", "Radgrid2_" + DateTime.Now.ToString());
    
            RadGrid2.DataSource = dt;
            RadGrid2.DataBind();
        }
    
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "RadGrid1")
            {
                NewMethod();
            }
            else if (e.Argument == "RadGrid2")
            {
                Thread.Sleep(5000);
                NewMethod2();
            }
        }
    }
