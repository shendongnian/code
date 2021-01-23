    public static int indextodelete;
    private void List1_Click(object sender, EventArgs e)
    {
        DialogResult result1 = MessageBox.Show("Are you sure you want to remove \"" + glossarywords.SelectedItem + "\" as a non specific word?", "Domain Expert", MessageBoxButtons.YesNo);
        if (result1 == DialogResult.Yes)
        {
            // remove based on object
            List1.Items.Remove(List1.SelectedItem);
            
            indextodelete = List1.Items.IndexOf(List1.SelectedItem.ToString());
            // remove based on index.
            List2.Items.RemoveAt(indextodelete);
            List3.Items.RemoveAt(indextodelete);
        }
    }
