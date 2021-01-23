    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       Item item = (Item)listBox1.SelectedItem;
       txtName.Text = item.Name;
       txtPrice.Text = item.Price;
       txtUrl.Text = item.Url;
    }
