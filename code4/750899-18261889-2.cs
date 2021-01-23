    protected void dcDdl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (recPartDdl.SelectedItem.Text != "All")
        {
            string value = (sender as DropDownList).SelectedValue.ToString();
  
            foreach(...)
            {
                ...
            }
        }
    }
