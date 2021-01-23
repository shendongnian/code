            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                    if (txtuser.Text == "User" && txtPassword.Text == "Password")
                    {
                        Session["username"] = txtuser.Text;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Username/Password";
                    }
            }
