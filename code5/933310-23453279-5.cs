    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\My Projects\\practice\\asp.net\\drpdTest\\App_Data\\Database.mdf;Integrated Security=True;User Instance=True");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCategory();
            }
        }
    
        private void ConnectionStatus()  // Checking connection Status either it is open or not
        {
            if (ConnectionState.Closed == con.State)
            {
                try
                {
                    con.Open();
                }
                catch (SqlException ex)
                {
                    Response.Write("<script language= 'JavaScript'> alert('" + ex.Message + "')</script>");
                }
            }
        }
    
        private void bindCategory()  // binding data to DropDownList
        {
            ConnectionStatus();
            string Qry = "select * from category";
            SqlDataAdapter da = new SqlDataAdapter(Qry, con);
            da.Fill(ds);
            drpdKategoria.DataSource = ds;
            drpdKategoria.DataValueField = "category_id";  // Value of bided list in your dropdown in your case it will be CATEGORY_ID
            drpdKategoria.DataTextField = "category_name"; // this will show Category name in your dropdown
            drpdKategoria.DataBind();
            con.Close();
            con.Dispose();
            ds.Dispose();
            da.Dispose();
        }
        private void insertData()
        {
            ConnectionStatus();  // Checking connection state either it is open or not.
            string Qry = "insert into article (categories_id) values('"+drpdKategoria.SelectedValue+"')";
            SqlCommand cmd = new SqlCommand(Qry, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                Response.Write("<script language= 'JavaScript'> alert('Record Inserted Please Check Your table')</script>");
                con.Close();
                con.Dispose();
            }
            catch (SqlException ex)
            {
                Response.Write("<script language= 'JavaScript'> alert('" + ex.Message + "')</script>");
            }
    
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            insertData();
        }
    }
