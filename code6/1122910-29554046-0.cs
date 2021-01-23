    public void PublicationReporting() {
    
                //connection for the datareader
                string csoWConn = ConfigurationManager.ConnectionStrings["RegisterCon"].ToString();
                SqlConnection csoW_connection = new SqlConnection(csoWConn);
                string database = csoW_connection.DataSource.ToString();
                csoW_connection.Open();
    
                if (Publications == null)
                {
                    Publications.Dispose();
    
                    ////
                    String MyString = @"UPDATE tb_Quadrennial_Report SET PublicationsPath='' WHERE Org_ID = '" + Accrediated_Orgs.SelectedValue + "'";
                    SqlCommand MyCmd = new SqlCommand(MyString, csoW_connection);
                    int LastInsertedRecordID;
    
                    LastInsertedRecordID = Convert.ToInt32(MyCmd.ExecuteScalar());
    
    
                }
                else
                {
                    int filesizeP = Publications.PostedFile.ContentLength;
    
                    if (filesizeP > 2097152)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Maximum File size  For Publication is 2.0 MB');", true);
                    }
    
                    else
                    {
    
                        const string ReportDirectory = "REPORTS/";
    
                        //publication 
                        string publicationPath = ReportDirectory + Publications.FileName;
                        string fileNameWithoutExtensionPub = System.IO.Path.GetFileNameWithoutExtension(Publications.FileName);
    
                        int iteration = 1; while (System.IO.File.Exists(Server.MapPath(publicationPath)))
                        {
                            publicationPath = string.Concat(ReportDirectory, fileNameWithoutExtensionPub, "-", iteration, ".pdf");
                            iteration++;
                        }
    
    
                        Publications.SaveAs(Server.MapPath(publicationPath));
    
                        String MyString = @"UPDATE tb_Quadrennial_Report SET PublicationsPath='" + publicationPath + "' WHERE Org_ID = '" + Accrediated_Orgs.SelectedValue + "'";
                        SqlCommand MyCmd = new SqlCommand(MyString, csoW_connection);
                        int LastInsertedRecordID;
    
                        LastInsertedRecordID = Convert.ToInt32(MyCmd.ExecuteScalar());
                    }
    
                }
    
            }
