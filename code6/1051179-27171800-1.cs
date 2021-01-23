     protected void grdCSRPageData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool IsUpdated = false;
            //getting key value, row id
            int Id = Convert.ToInt32(grdCSRPageData.DataKeys[e.RowIndex].Value.ToString());
            //get all the row field detail here by replacing id's in FindControl("")..
            GridViewRow row = grdCSRPageData.Rows[e.RowIndex];
            TextBox PageTitle = ((TextBox)(row.Cells[0].Controls[0]));
            TextBox PageDesc = ((TextBox)(row.Cells[1].Controls[0]));
            TextBox MetaTitle = ((TextBox)(row.Cells[2].Controls[0]));
            TextBox Metakeywords = ((TextBox)(row.Cells[3].Controls[0]));
            TextBox Metadesc = ((TextBox)(row.Cells[4].Controls[0]));
            TextBox ddlActive = ((TextBox)(row.Cells[5].Controls[0]));
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE tbl_Pages SET page_title=@page_title,page_description=@page_description,meta_title=@meta_title,meta_keywords=@meta_keywords,meta_description=@meta_description,Active=@Active  WHERE Id=@Id";
                
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@page_title", PageTitle.Text);
                cmd.Parameters.AddWithValue("@page_description", PageDesc.Text);
                cmd.Parameters.AddWithValue("@meta_title", MetaTitle.Text);
                cmd.Parameters.AddWithValue("@meta_keywords", Metakeywords.Text);
                cmd.Parameters.AddWithValue("@meta_description", Metadesc.Text);
                cmd.Parameters.AddWithValue("@Active", ddlActive.Text == "1" ? true : false);
               
                cmd.Connection = conn;
                conn.Open();
                IsUpdated = cmd.ExecuteNonQuery() > 0;
                conn.Close();
            }
            if (IsUpdated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('page updated sucessfully');window.location ='csrpage.aspx';", true);
                BindGrid();
            }
            else
            {
                //Error while updating details
                grdCSRPageData.EditIndex = -1;
                //bind gridview here..
                grdCSRPageData.DataBind();
            }
        }
