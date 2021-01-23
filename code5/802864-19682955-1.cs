    Stopwatch sw = new Stopwatch();
    sw.Start();
    var items = new ToolStripItem[menuStrip1.Items.Count];
    menuStrip1.Items.CopyTo(items, 0);
    var itemList = new List<ToolStripItem>(items);
    for (int i = 0; i < 1000; i++)
        itemList.Insert(2, new ToolStripMenuItem { Text = "Hello" + i.ToString() });
    menuStrip1.Items.Clear();
    menuStrip1.Items.AddRange(itemList.ToArray());
    sw.Stop();
    label1.Text = sw.ElapsedMilliseconds.ToString();
