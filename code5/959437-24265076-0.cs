    private void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text == "")
        {
            MessageBox.Show("Please fill in the textbox!");
            return;
        }
    
        else
        {
            gridViewContact.SelectionMode = GridViewSelectionMode.FullRowSelect;
    
    		bool found = false;
            foreach (GridViewRowInfo row in gridViewContact.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(txtSearch.Text) || row.Cells[1].Value.ToString().Contains(txtSearch.Text) || row.Cells[2].Value.ToString().Contains(txtSearch.Text))
                {
    			    found = true;
                    row.IsSelected = true;
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show("Nothing found!");
            }
        }
    }
