     protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         int userid =Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["UserId"].ToString());
         string username = gvDetails.DataKeys[e.RowIndex].Values["UserName"].ToString();
         con.Open();
         SqlCommand cmd = new SqlCommand("delete from Employee_Details where UserId=" +userid, con);
         int result = cmd.ExecuteNonQuery();
         con.Close();
         if (result == 1)
         {
        BindEmployeeDetails();
        lblresult.ForeColor = Color.Red;
        lblresult.Text = username + " details deleted successfully";
         }
      }
