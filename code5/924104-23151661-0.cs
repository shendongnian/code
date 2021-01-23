    protected void Page_Load(object sender, EventArgs e)
    {
          if(!IsPostBack)
          {
            txtUserId.Text = Request.Cookies["txtUserName"].Value;
            string con_string = @"data Source= 10.10.10.5; initial catalog= test; user= xx; password= xxxxxxxxx;";
            SqlConnection con = new SqlConnection(con_string);
            SqlCommand cmd = new SqlCommand("select FirstName, LastName, Password, EmailId, MobileNumber from ExpenseManagement where UserId ='"+txtUserId.Text+"'", con);
            cmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ......
            btnUpdate.Visible = false;
       }
    }
