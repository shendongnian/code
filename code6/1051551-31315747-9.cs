    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
               int index = Convert.ToInt32(e.CommandArgument);
               GridViewRow selectedRow = GridView1.Rows[index];
               string id = selectedRow.Cells[0].Text; //assuming your ID is the first column of your grid
               SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString); //assuming your connection string is in web.config
               con.Open();
               SqlCommand sq = new SqlCommand("DELETE FROM myTable where id='" + id + "'", con);
               sq.ExecuteNonQuery();
               con.Close();
            }
        }
