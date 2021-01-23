    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Get the currently selected item in the ListBox. 
        string curItem = listBox1.SelectedItem.ToString();
    
        switch(curItem)
        {
            case : "blah" 
                panel1.visible = false;
                panel2.visible = true;
                break;
            case : "blah" 
                panel2.visible = false;
                panel3.visible = true;
                break;
            case : "blah" 
                panel3.visible = false;
                panel4.visible = true;
                break;
        }
    }
