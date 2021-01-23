        private void mygrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView temp = (DataGridView)sender;
            foreach (DataGridViewRow rw in temp.Rows)
            {
                // here 0 indicating the checbox column is the first column in grid
                // first column so index would be 0.  true will check the checkbox
                rw.Cells[0].Value = true;
            }
         }
