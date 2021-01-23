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
                else{
