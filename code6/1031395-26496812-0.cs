    public partial class WebForm4 : System.Web.UI.Page
    {
    
        private static DataTable MyDataTable = new DataTable();
    
        static WebForm4()
        {
            MyDataTable.Columns.Add("sno");
            MyDataTable.Columns.Add("name");
        }
        private void AddNewRow()
        {
            MyDataTable.Rows.Add(MyDataTable.NewRow());
            GridView1.DataSource = MyDataTable;
            GridView1.DataBind();
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
    
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MyDataTable.Rows.RemoveAt(e.RowIndex);
            GridView1.DataSource = MyDataTable;
            GridView1.DataBind();
        }
    }
