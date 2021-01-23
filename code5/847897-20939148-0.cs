    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var item = (myListboxItem)listBox1.Items[e.Index];
        e.DrawBackground();
        using (var brush = new SolidBrush(item.ItemColor))
            e.Graphics.DrawString(item.Message, listBox1.Font, brush, e.Bounds);
    }
