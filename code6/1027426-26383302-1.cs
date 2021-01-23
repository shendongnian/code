    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawString(yourText, yourFont, yourBrush, 
                              float.Parse(textBox1.Text), float.Parse(textBox2.Text));
    }
    // this will show up only after leaving the textbox:
    private void textBox_Leave(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    // this will provide a live change:
    private void textBox_TextChanged(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
