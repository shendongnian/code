    private void button4_Click(object sender, EventArgs e)
    {
      if(ListU.SelectedValue == null || string.IsNullOrEmpty(Convert.ToString(ListU.SelectedValue)))
      {
        MessageBox.Show("Select something from the listbox.");
        return;
      }
    .....
