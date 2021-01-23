    private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Are you sure you want to delete this element?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    tmpList.remove(item.Index);//remove item from tmpList used to update the passed in list                    
                    dataGridView1.Rows.RemoveAt(item.Index);//remove the item from the dataGrid
                }
            }
        }
