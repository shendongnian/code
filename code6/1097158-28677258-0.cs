    private void tsbSearch_Click(object sender, EventArgs e)
        {
            if (tstxtSearch.Text.Length > 0)
            {
                this.nEAR_MISSBindingSource.Filter = "NMS_Description LIKE '*" + tstxtSearch.Text + "*' OR LongDesc LIKE '*" + tstxtSearch.Text + "*' OR LOCATION LIKE '*" + tstxtSearch.Text + "*'";
            }
            else
            {
                this.nEAR_MISSBindingSource.Filter = "";
            }
        }
        private void tstxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                tsbSearch_Click(sender, e);
            }
        }
