        var cm = new ContextMenuStrip();
        cm.Items.AddRange(new[]
        {
            new ToolStripMenuItem("Menu item", null, (sender2, e2) =>
            {
                Console.WriteLine("Menu item is clicked!");
            })
        });
        cm.Show(this, ((MouseEventArgs)e).Location);
