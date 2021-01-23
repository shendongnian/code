    //  This is in form 1
    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (listBox1.SelectedIndex > -1)
        {
            // Make sure form2 is a class variable in form1
            if (form2 != null)
            {
                form2.AddToTextBox(listBox1.SelectedItem.ToString());
            }
        }
    }
    // This is in form 2
    public void AddToTextBox(string selectedItem)
    {
        Nametxt.Text = selectedItem;
    }
