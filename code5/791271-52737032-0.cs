    private void dgEvents_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
                      
            FormatRow(dgEvents.Rows[e.RowIndex]);
            
        }
    private void FormatRow(DataGridViewRow myrow)
        {
            try
            {
                if (Convert.ToString(myrow.Cells["LevelDisplayName"].Value) == "Error")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToString(myrow.Cells["LevelDisplayName"].Value) == "Warning")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (Convert.ToString(myrow.Cells["LevelDisplayName"].Value) == "Information")
                {
                    myrow.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            catch (Exception exception)
            {
                onLogs?.Invoke(exception.Message, EventArgs.Empty);
            }
        }
