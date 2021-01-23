     protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(con_string);
            string query = ("select count(*) from UserProfile where UserId ='" + txtUserId.Text + "' and Password='" + txtPassword.Text + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Connection = con;
            con.Open();
            int u = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
            if (u > 0 && Captcha1.UserValidated)
            {
                // Adding Session to your page
                Session["user"] = txtUserId.Text;
    
                Response.Cookies["txtUserName"].Value = txtUserId.Text;
                Response.Redirect("Main.aspx");
            }
            else if (u == 0)
            {
                lblCaptcha.Text = "Unauthorized User";
                txtCaptcha.Text = "";
                txtUserId.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                lblCaptcha.ForeColor = System.Drawing.Color.Red;
                lblCaptcha.Text = "You have Entered InValid Captcha Characters please Enter again";
                txtCaptcha.Text = "";
            }
    
        }
