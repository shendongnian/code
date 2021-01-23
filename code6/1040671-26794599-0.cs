    try
    {
        // run the query
        cmd.ExecuteNonQuery();
        lblInserted.Text = "Inserted:" + count;
        // MessageBox.Show("Inserted");
        lblInserted.Font = new System.Drawing.Font(lblInserted.Font, FontStyle.Bold);
        lblInserted.ForeColor = System.Drawing.Color.Green;
        count++;
        dataGridViewDisplayPanel.Rows[i].Cells[nextCell - 1].Style.BackColor = Color.Green;
        dataGridViewDisplayPanel.Rows[i].Cells[nextCell - 1].Value = "Inserted Successfully";
    }
    catch (Exception ee9)
    {
        // Deal with the error
        MessageBox.Show("Oops, it failed");
    }
