    private void searchTxt_TextChanged(object sender, EventArgs e)
            {
                if (comboSearch.SelectedItem == null)
                {
                    searchTxt.ReadOnly = true;
                    MessageBox.Show("Please select a search criteria");
                }
    
    
    
                else
                {
                    searchTxt.ReadOnly = false;
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "" + comboSearch.Text.Trim() + "like '%" + searchTxt.Text.Trim() + "%'";
                    dataGridView1.DataSource = dv;
                }
            }
