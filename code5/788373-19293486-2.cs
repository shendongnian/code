    using System;
    using System.Configuration;
    using System.Data;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Data.SqlClient;
    
    public partial class EditableGridView : System.Web.UI.Page
    {
     
        SqlConnection con;
        bool[] rowChanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationSettings.AppSettings["mycon"];
            con = new SqlConnection(conString);
            int totalRows = GridView1.Rows.Count;
            rowChanged = new bool[totalRows];
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    
        public void BindGrid()
        {
            SqlDataAdapter adap = new SqlDataAdapter("select * from items", con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
            int row = thisGridViewRow.RowIndex;
            rowChanged[row] = true;
        }
    
    
    
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                int totalRows = GridView1.Rows.Count;
                for (int r = 0; r < totalRows; r++)
                {
                    if (rowChanged[r])
                    {
                        GridViewRow thisGridViewRow = GridView1.Rows[r];
                        HiddenField hf1 = (HiddenField)thisGridViewRow.FindControl("HiddenField1");
                        string pk = hf1.Value;
                        TextBox tb1 = (TextBox)thisGridViewRow.FindControl("TextBox1");
                        string name = tb1.Text;
                        TextBox tb2 = (TextBox)thisGridViewRow.FindControl("TextBox2");
                        decimal price = Convert.ToDecimal(tb2.Text);
    
                        SqlCommand cmd = new SqlCommand("update items set name='" + name + "' , price='" + price + "' where INTERM_NO=' " + pk + "'", con);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        int temp = cmd.ExecuteNonQuery();
                        if (temp > 0)
                        {
                            lblMessage.Text = "Operation perform successfully";
                            con.Close();
                        }
    
    
                    }
                }
                GridView1.DataBind();
                BindGrid();
            }
        }
    }
