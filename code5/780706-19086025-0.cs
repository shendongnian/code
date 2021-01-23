    protected void sortImageButton_Click(object sender, ImageClickEventArgs e)
    {        
        string[] sort = new string[cartListBox.Items.Count];
    
        for (int i = 0; i < sort.Length; i++)
        {
            sort[i] = cartListBox.Items[i].ToString();
        }
        Array.Sort(sort);
        for (int i = 0; i < sort.Length; i++)
        {
            // reset the order for the cartListBox collection according to the sort array, if needed
        }
    }
