     private void button1_Click(object sender, EventArgs e)
            {
                AddItemDialog addItemDialog = new AddItemDialog(this);
                addItemDialog.Show();
               
            }
    // Add item form  the add item dialog
        public void AddFromItemDialog(ListViewItem itms)
        {
            listItems.Items.Add(itms);
        }
