    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                foreach (DataGridViewCell dc in dr.Cells)
                {
                    int x;
                    double y;
                    if (int.TryParse(dc.Value.ToString(),out x) || double.TryParse(dc.Value.ToString(),out y))
                    {
                        MessageBox.Show("You have to enter digits only");
                    }
                    
                }
            }
        }
