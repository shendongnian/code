    protected void grdPostData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bool IsUpdated = false;
        //getting key value, row id
        int Id = Convert.ToInt32(grdPostData.DataKeys[e.RowIndex].Value.ToString());
    
        //get all the row field detail here by replacing id's in FindControl("")..
    
        GridViewRow row = grdPostData.Rows[e.RowIndex];
        DropDownList ddlPostCategory = (DropDownList)row.FindControl("ddlPostCategory") ;
        string PostTitle = row.Cells[0].Text;
        string Postdesc = row.Cells[1].Text;
        string Active = row.Cells[2].Text;
    
        using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
    
            
            cmd.CommandText = "UPDATE tbl_Post SET title=@title, description=@description, active=@active WHERE Id=@Id";
    
            cmd.Parameters.Add("@Id",SqlDbType.Int).Value=Id;
            cmd.Parameters.Add("@title",SqlDbType.Varchar,100).Value=PostTitle ;
            cmd.Parameters.Add("@description",SqlDbType.Varchar,200).Value= Postdesc ;
            cmd.Parameters.Add("@Active",SqlDbType.Int).Value=Convert.ToInt32(Active);
    
            cmd.Connection = conn;
            conn.Open();
            IsUpdated = cmd.ExecuteNonQuery() > 0;
            conn.Close();
        }
        if (IsUpdated)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('page updated sucessfully');window.location ='csrposts.aspx';", true);
            BindGrid();
        }
        else
        {
            //Error while updating details
    
            grdPostData.EditIndex = -1;
            //bind gridview here..
            //GET GDATA FROM DATABASE AND BIND TO GRID VIEW
        }
    
    }
