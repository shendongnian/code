        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = BLL.userLogin(TextBox1.Text, TextBox2.Text);
                Response.Redirect("SubscribePage.aspx"); /* If it reaches here, everything is okay */
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
