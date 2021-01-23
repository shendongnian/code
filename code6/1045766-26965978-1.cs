    private void btn_savedp_Click(object sender, EventArgs e)
        {
    
            // Retrieve the connection string from the settings file.
            string conString = Properties.Settings.Default.EchonologiaConnectionString;
    
            string sqlQuery = "INSERT INTO tb_DataPoint (PierID, InspectDate, DPName, ZoneColumn, ZoneRow, Result, Longitude, Latitude)";
            sqlQuery += "VALUES (@PierID, @InspectDate, @DPName, @ZoneColumn, @ZoneRow, @Result, @Longitude, @Latitude)";
    
    
            // Open the connection using the connection string.
            using (SqlCeConnection con = new SqlCeConnection(conString))
            {
                    con.Open();
                // Insert into the SqlCe table. ExecuteNonQuery is best for inserts.
                    for (int i = 0; i < dgDataPoint.Rows.Count; i++)
                    {
                         using (SqlCeCommand com = new SqlCeCommand(sqlQuery, con))
                         {
    
                             com.Parameters.AddWithValue("DPName", dgDataPoint.Rows[i].Cells["DataPointName"].Value);
                             com.Parameters.AddWithValue("ZoneColumn", dgDataPoint.Rows[i].Cells["ZoneColumn"].Value);
                             com.Parameters.AddWithValue("ZoneRow", dgDataPoint.Rows[i].Cells["ZoneRow"].Value);
                             com.Parameters.AddWithValue("Result", dgDataPoint.Rows[i].Cells["Result"].Value);
                             com.Parameters.AddWithValue("Longitude", dgDataPoint.Rows[i].Cells["Longitude"].Value);
                             com.Parameters.AddWithValue("Latitude", dgDataPoint.Rows[i].Cells["Latitude"].Value);
                             com.Parameters.AddWithValue("PierID", cbPier.Text);
                             com.Parameters.AddWithValue("InspectDate", dtInspect.Text);
    
                             com.ExecuteNonQuery();
                        }
    
                    com.Parameters.Clear();            
                      
                    }
    
                con.Close();  
            }
