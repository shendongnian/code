    //TextChanged event handler for your textBox1
    private void textBox1_TextChanged(object sender, EventArgs e) {
            ListViewItem item = listView1.Items.OfType<ListViewItem>()
                                         .FirstOrDefault(x => x.Text.Equals(textBox1.Text, StringComparison.CurrentCultureIgnoreCase));
            if (item != null){
                listView1.SelectedItems.Clear();
                item.Selected = item.Focused = true;
                listView1.Focus();//Focus to see it in action because SelectedItem won't look like selected if the listView is not focused.
            }
    }
