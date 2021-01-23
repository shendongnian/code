    int rowIndex=0;//stroe the row index
    string perId=String.Empty//store the PersonnelID or 'long' whatever 
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long perID;
            // Only if data cells are clicked and not the column names
            if (e.RowIndex >= 0)
            {
                // Gets the PersonnelID which is in column[3] of each row as a string
                perId = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                rowIndex = e.RowIndex; // store the selected row index
                // Check if the string is empty
                if (!(String.IsNullOrEmpty(SperID)))
                {
                    // Converts PersonnelID from string to long
                    perID = long.Parse(perId);
                    MessageBox.Show(perId);                    
                }                
            }            
        }
