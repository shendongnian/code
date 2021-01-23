        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            try
            {
                string UN = Session["New"].ToString(); ;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string UserSearch = "SELECT * FROM UserUpload WHERE UserName = @un";
                SqlCommand com = new SqlCommand(UserSearch, conn);
                com.Parameters.Add(new SqlParameter("@un", UN));
                com.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ("Error:" + ex.Message);
            }
        }
