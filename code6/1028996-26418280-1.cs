       int rowindex;
       if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
       {
           rowindex = dataGridView1.CurrentRow.Index;
           DataGridViewRow row = this.dataGridView1.Rows[rowindex];
           txtpaX.Text = row.Cells["X"].Value.ToString();
           txtpaY.Text = row.Cells["Y"].Value.ToString();
           lblinfo.Text = row.Cells["item"].Value.ToString();
    
           xposition = int.Parse(txtpaX.Text);
           yposition = int.Parse(txtpaY.Text);
           flag = 1;
       }
       
