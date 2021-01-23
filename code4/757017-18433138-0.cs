    private void checkBox1_Checkedchanged(object sender, EventArgs e)
    {
        if (!textBox1.Visible) {
            textBox1.Location = new Point(textBox1.Left + panel1.AutoScrollPosition.X,
                                          textBox1.Top  + panel1.AutoScrollPosition.Y);
            textBox1.Visible = true;
        }
    }
