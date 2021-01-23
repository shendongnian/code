    protected void Button_Login_Click(object sender, EventArgs e)
    {
            SqlConnection conn = new SqlConnection("Data Source=TOSHIBA0007\\TESTSERVER;Initial Catalog=users;Integrated Security=True");
            conn.Open();
            string checkuser = "select count(*) from userdatabase where Username=@username";
            SqlCommand UserComm = new SqlCommand(checkuser, conn);
            UserComm.Parameters.AddWithValue("@username",Username.Text);
            int temp = Convert.ToInt32(UserComm.ExecuteScalar());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPasswordQuery = "select Password from userdatabase where Username=@username";
                SqlCommand passCom = new SqlCommand(checkPasswordQuery, conn);
                passCom.Parameters.AddWithValue("@username",Username.Text);
                string password = passCom.ExecuteScalar().ToString().Replace(" ", "");
                if(password == Password.Text)
                {
                    Session["New"] = Username.Text;
                    Response.Write("Password Accepted");
                }
                else
                {
                    Response.Write("Password Incorrect");
                }        
            }
            else
            {
                Response.Write("Username is Incorrect");
            }
    }
