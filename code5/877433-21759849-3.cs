    protected void Button_Login_Click(object sender, EventArgs e)
    {
            SqlConnection conn = new SqlConnection("Data Source=TOSHIBA0007\\TESTSERVER;Initial Catalog=users;Integrated Security=True");
            conn.Open();
            string checkuser = "select count(*) from userdatabase where Username=@username and Password=@password";
            SqlCommand UserComm = new SqlCommand(checkuser, conn);
            UserComm.Parameters.AddWithValue("@username",Username.Text);
            UserComm.Parameters.AddWithValue("@password",Password.Text);
            int temp = Convert.ToInt32(UserComm.ExecuteScalar());
            conn.Close();
            if (temp == 1)
            {
               Session["New"] = Username.Text;
               Response.Write("User Is Valid!");
            }
            else
            {
               Response.Write("Invalid User Credentials!");
            }   
    }
