    var items = new List<string>();           
    foreach (ListItem li in ListBox1.Items)
    {
        if (li.Selected)
        {
            items.Add(ListBox1.SelectedItem.Text);
        }
    }
    cmd.Parameters.AddWithValue("@TestName", string.Join(",", items));
