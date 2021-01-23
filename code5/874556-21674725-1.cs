    Color selectedColor;
    
    private void label1_Paint(object sender, PaintEventArgs e)
    {
        ControlPaint.DrawBorder(e.Graphics, label1.DisplayRectangle, selectedColor, ButtonBorderStyle.Solid);
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0)
        {
            selectedColor = Color.Red;         
        }
        if (comboBox1.SelectedIndex == 1)
        {
            selectColor = Color.Blue;
        }
        label1.Invalidate();
        label1.Update();
    }
