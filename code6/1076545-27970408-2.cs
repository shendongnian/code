    private void prepare_Click_1(object sender, EventArgs e)
    {
        // we sit inside a Panel
        listView1.Parent = panel1;
        // initially they have the same size
        listView1.Size = panel1.Size;
        listView1.Location = Point.Empty;
        // a few test items
        for (int i = 0; i < 100; i++)
            listView1.Items.Add("Item " + i);
        // now grow the height to display all items:
        int cols = listView1.Width / listView1.TileSize.Width;
        listView1.Height = (listView1.Items.Count / cols) * listView1.TileSize.Height;
    }
    // moving the LV up looks like scrolling down..
    private void scrollDown_Click(object sender, EventArgs e)
    {
        listView1.Top -= listView1.TileSize.Height;
        if (listView1.Bottom < panel1.Height) 
            listView1.Top = -listView1.Height + panel1.Height;
    }
    // moving the LV down looks like scrolling up..
    private void scrollUp_Click_1(object sender, EventArgs e)
    {
        listView1.Top += listView1.TileSize.Height;
        if (listView1.Top > 0) listView1.Top = 0;
    }
