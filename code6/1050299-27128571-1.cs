      protected void grdCSRPageData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool IsDeleted = false;
            //getting key value, row id
            int Id = Convert.ToInt32(grdCSRPageData.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM tbl_Pages WHERE Id=@ID";
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.Connection = conn;
                    conn.Open();
                    IsDeleted = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            if (IsDeleted)
            {
                //record has been deleted successfully!
                //call here gridview bind method and replace it..
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Page Succesfully deleted');window.location ='csrpage.aspx';", true); ;
                grdCSRPageData.DataBind();
            }
            else
            {
                //Error while deleting record
                Response.Write("Some error");
            }
        }
