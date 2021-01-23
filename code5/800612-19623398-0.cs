    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    namespace ASP_Web_Datagrid
    {
        public partial class sapnamalik_DataGrid : System.Web.UI.Page
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    BindData();
    
                }
            }
            public void BindData()
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
                cmd.CommandText = "Select * from Employee";
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Open();
                cmd.ExecuteNonQuery();
                Grid.DataSource = ds;
                Grid.DataBind();
                con.Close();
            }
            protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
            {
                Grid.CurrentPageIndex = e.NewPageIndex;
                BindData();
            }
            protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
            {
            http://www.c-sharpcorner.com/UploadFile/631fc0/runtime-table-creation-in-wpf/.EditItemIndex = e.Item.ItemIndex;
                BindData();
            }
            protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
            {
                Grid.EditItemIndex = -1;
                BindData();
            }
            protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
                cmd.Connection = con;
                int EmpId = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
                cmd.CommandText = "Delete from Employee where EmpId=" + EmpId;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Grid.EditItemIndex = -1;
                BindData();
            }
            protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
                cmd.Parameters.Add("@F_Name", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
                cmd.Parameters.Add("@L_Name", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
                cmd.Parameters.Add("@City", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
                cmd.Parameters.Add("@EmailId", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
                cmd.Parameters.Add("@EmpJoining", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                cmd.CommandText = "Update Employee set F_Name=@F_Name,L_Name=@L_Name,City=@City,EmailId=@EmailId,EmpJoining=@EmpJoining where EmpId=@EmpId";
                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Grid.EditItemIndex = -1;
                BindData();
            }
            protected void btnsubmit_Click(object sender, EventArgs e)
            {
                SqlConnection con;
                con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("Insert into Employee (EmpId,F_Name,L_Name,City,EmailId,EmpJoining) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            protected void btnReset_Click(object sender, EventArgs e)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
            protected void btnOk_Click(object sender, EventArgs e)
            {
                BindData1();
            }
            public void BindData1()
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
                cmd.CommandText = "Select * from Employee";
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Open();
                cmd.ExecuteNonQuery();
                Grid1.DataSource = ds;
                Grid1.DataBind();
                con.Close();
            }
        }
    }
