    protected void listbox_mar_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < listbox_mar.Items.Count; i++)
        {
            if (listbox_mar.Items[i].Selected)
            {
                lbl_mar_cat.Text += listbox_mar.Items[i].Text+ " , " ;
                listbox_mar.Items.Remove(listbox_mar.Items[i]);
            }
        }       
    }
