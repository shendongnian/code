    private void btnLogin_Click(object sender, EventArgs e)
        {
            string requiredUserId;
            
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ProgII Project\MoneyManager\MoneyManager\MsUser.mdf;Integrated Security=True;User Instance=True");
    
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(userID),UserId From MsUser where username='"+txtUsername.Text+"' and password='"+txtPassword.Text+"' Group By userID",cn);
    
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
                {
                    this.Hide();
                    requiredUserId=dt.Rows[0][1].ToString(); //Use this requiredUserId in your next form!!
                }
            else
            {
                MessageBox.Show("your id or password is wrong");
            }
    
        }
