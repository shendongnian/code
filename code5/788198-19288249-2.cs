    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {  
       if(listBox1.SelectedIndex != -1)  {         
           // Get the currently selected item in the ListBox.
           total = listBox1.SelectedItem.ToString();
           dataGridView1.Rows.Add(new object[] {total});
           listbox1.ClearSelected();
       }
    }
