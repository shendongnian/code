    private void dgResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Would be nice if we could do this on databind of each row instead and avoid looping
            for (DataGridViewRow row in dgResults.Rows)
            {
                if (row.Cells[5].Value.ToString() == "0")
                {
                   row.DefaultCellStyle.ForeColor = Color.White;                
                }
            }
        }
