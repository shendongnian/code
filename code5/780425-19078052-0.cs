    private void btnColor_Click(object sender, EventArgs e)
    {
        ColorDialog color = new ColorDialog();
        if (color.ShowDialog() == DialogResult.OK)
        {
            richTextBox1.ForeColor = color.Color;
        }
    }
    private void btnFont_Click(object sender, EventArgs e)
    {
        FontDialog font = new FontDialog();
        if (font.ShowDialog() == DialogResult.OK)
        {
            richTextBox1.Font = font.Font;
        }
    }
    private void btnSend_Click(object sender, EventArgs e)
    {
        listView1.Items.Add(richTextBox1.Text);
        listView1.Items[listView1.Items.Count - 1].ForeColor = richTextBox1.ForeColor;
        listView1.Items[listView1.Items.Count - 1].Font = richTextBox1.Font;
    }
