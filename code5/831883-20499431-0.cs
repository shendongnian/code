    SqlCommand fillRights = new SqlCommand("SELECT * FROM [Rights]", sqlConnection);
    sqlConnection.Open();
    SqlDataReader readerRights = fillRights.ExecuteReader();
    
    DataGridViewComboBoxColumn dgvRightsColumn= dataGridView1.Columns[2] as DataGridViewComboBoxColumn;
    while (readerRights.Read())
    {                
     dgvRightsColumn.Items.Add(Convert.ToString(readerRights["RightName"]));
    }  
    readerRights.Close();
