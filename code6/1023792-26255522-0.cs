    public partial class Default3 : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection(@"connectionString");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldropdown();
            }
        }
    
        private void filldropdown()
        {
            SqlCommand cmd = new SqlCommand("Select EmpID from Tbl_Emp", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            TextBox3.Items.Clear();
            if (dr.HasRows)
            {
    
                while (dr.Read())
                {
                    TextBox3.Items.Add(dr["EmpID"].ToString());
                }
            }
            dr.Close();
            con.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Emp values(@id,@name,@image)", con);
            cmd.Parameters.AddWithValue("@id", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
    
            int img = FileUpload1.PostedFile.ContentLength;
    
            byte[] msdata = new byte[img];
    
            FileUpload1.PostedFile.InputStream.Read(msdata, 0, img);
    
            cmd.Parameters.AddWithValue("@image", msdata);
    
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
    
            con.Close();
            filldropdown();
            Response.Write("Data Saved ....");
    
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Emp where EmpID=@id", con);
            cmd.Parameters.AddWithValue("@id", TextBox3.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows && dr.Read())
            {
                TextBox1.Text = dr["EmpID"].ToString();
                TextBox2.Text = dr["EmpName"].ToString();
                Image1.ImageUrl = "Handler.ashx?EmpID=" + TextBox3.Text;
            }
            else
            {
                Response.Write("Record With This ID Note Found");
            }
            dr.Close();
        }
    }
