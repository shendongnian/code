    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString);
            foreach (GridViewRow row in ImagesGrid.Rows)
            {   
                var title = row.FindControl("txtTitle") as TextBox;
                var description = row.FindControl("txtDescription") as TextBox;
                var imageFile = row.FindControl("flUpload") as FileUpload;
                var chkDefault = row.FindControl("chkDefault") as CheckBox;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Insert into tbl_galleries_stack (gallery_id,img_title,img_desc,img_path,isDefault) values (@gallery_id,@img_title,@img_desc,@img_path,@isDefault)", conn);
                    cmd1.Parameters.Add("@gallery_id", SqlDbType.Int).Value = Convert.ToInt32(ddlgallery.SelectedValue);
                    cmd1.Parameters.Add("@img_title", SqlDbType.NVarChar).Value = title.Text;
                    cmd1.Parameters.Add("@img_desc", SqlDbType.NVarChar).Value = description.Text;
                    if (imageFile.HasFile)
                    {
                        imageFile.SaveAs(Server.MapPath("~/GalleryImages/") + imageFile.FileName);
                        cmd1.Parameters.Add("@img_path", SqlDbType.NVarChar).Value = "~/GalleryImages/" + imageFile.FileName;
                    }
                    cmd1.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = chkDefault.Checked;
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Teachers profile added sucessfully');window.location ='csrgalleriesstack.aspx';", true);
                }
            }
        }
