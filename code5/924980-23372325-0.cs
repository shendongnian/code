     protected void lbStart_Click(object sender, EventArgs e)
     {
            LinkButton lbtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lbtn.NamingContainer;
            if (row != null)
            {
               
                int QID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                string status = "Closed";
                string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(con);
                string qry = "UPDATE [MQ_Quiz] SET QuizStatus='" + status + "' WHERE QuizID='" + QID + "'";
                SqlCommand cmd = new SqlCommand(qry, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                GridView1.DataBind();
            }
        
    }
