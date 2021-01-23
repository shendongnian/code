      protected void lnkDownload_Click(object sender, EventArgs e)
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int fileid = Convert.ToInt32(gvCadPdf.DataKeys[gvrow.RowIndex].Value.ToString());
                string name, type;
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = " SELECT Id, Cad_File, Cad_File_Name, type From  tbl_CadFileUpload   WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@id", fileid);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Response.ContentType = dr["type"].ToString();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["Cad_File_Name"] + "\"");
                            Response.BinaryWrite((byte[])dr["Cad_File"]);
                            Response.End();
                        }
                    }
                }
            }
    
