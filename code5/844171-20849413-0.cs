    foreach (ListViewItem item in listView1.Items)
    {
        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems) 
        {
            if (subItem.Text == textBox1.Text)
            {
                item.UseItemStyleForSubItems = false;
                subItem.BackColor = Color.LightBlue;
            }
        }
    }
