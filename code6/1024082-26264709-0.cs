    private void editButton_Click(object sender, EventArgs e) 
    {
       if (DataGridView1.SelectedRows.Count > 0)
       {
          DataGridViewRow row =  dataGridView1.SelectedRows[0];
          if (itemList.SelectedIndex >= 0) 
          {
             int newInt = itemList.SelectedIndex;
             Form form = new NewItemW(
                             selectedFolder, this, items[newInt], WindowEnum.ItemEdit);
             form.Show();
          }
       }
    }
