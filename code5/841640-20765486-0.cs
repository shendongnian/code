        StringBuilder output = new StringBuilder();
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                output.Append(item.Text);
            }
        }
        foreach (ListItem item in ListBox2.Items)
        {
            if (item.Selected)
            {
                output.Append(item.Text);
            }
        }
