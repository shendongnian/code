    private void txtGrid_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(cbGrid.Text))    
        {
            // only run when not empty
            DataView dv = new DataView(dt);
            dv.RowFilter = ""+cbGrid.Text + " like '%" + txtGrid.Text + "%'";
            gridPlayers.DataSource = dv;
        }
    }
