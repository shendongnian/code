    protected void btnSubmit_Click(object sender, EventArgs e)
        {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString);
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    if (fupreportfile.HasFiles)
                    {
                        int count = CheckFileExists(fupreportfile.PostedFile.FileName);
                        fupreportfile.SaveAs(Server.MapPath("~/ReportFolder/" + fupreportfile.PostedFile.FileName));
                        if (count > 0)
                        {
                            cmd.CommandText = " Update tbl_reports SET revision=@revision Where Id=@Id";
                            cmd.Parameters.AddWithValue("@Id", GetIdByFileName(fupreportfile.PostedFile.FileName));
                            cmd.Parameters.Add("@revision", SqlDbType.VarChar).Value = (count + 1).ToString();
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Reports updated sucessfully');window.location ='csrreports.aspx';", true);
                        }
                        else
                        {
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("Insert into tbl_reports (NgoId,report_type_id,report_title,report_file,report_desc,revision) values(@NgoId, @report_type_id, @report_title,@report_file,@report_desc,@revision)", conn);
                            cmd1.Parameters.Add("@NgoId", SqlDbType.Int).Value = ddlNgoName.SelectedValue;
                            cmd1.Parameters.Add("@report_type_id", SqlDbType.Int).Value = ddlReportType.SelectedValue;
                            cmd1.Parameters.Add("@report_title", SqlDbType.NVarChar).Value = txtreporttitle.Text;
                            cmd1.Parameters.Add("@report_file", SqlDbType.VarChar).Value = fupreportfile.PostedFile.FileName;
                            cmd1.Parameters.Add("@report_desc", SqlDbType.NVarChar).Value = txtreportdescription.Text;
                            cmd1.Parameters.Add("@revision", SqlDbType.VarChar).Value = (count + 1).ToString();
                            cmd1.ExecuteNonQuery();
                            conn.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Reports added sucessfully');window.location ='csrreports.aspx';", true);
                        }
                    }
                }
        }
