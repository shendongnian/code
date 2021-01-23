    var items = new List<string>();           
    foreach (ListItem li in ListBox1.Items)
    {
        if (li.Selected)
        {
            items.Add(li.Text);
        }
    }
    cmd.Parameters.AddWithValue("@TestName", string.Join(",", items));
