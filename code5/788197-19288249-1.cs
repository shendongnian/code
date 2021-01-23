    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // Get the currently selected item in the ListBox.
       total = listBox1.SelectedIndex.ToString();
       
       if(total != -1)  {         
         dataGridView1.Rows.Add(new object[] {total});
         listbox1.ClearSelected();
       }
    }
