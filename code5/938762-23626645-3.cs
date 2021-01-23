    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        Font font = (sender as ComboBox).Font;
        Brush backgroundColor;
        Brush textColor;
        if (e.Index == 1 || e.Index == 3)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = Brushes.Red;
                textColor = Brushes.Black;
            }
            else
            {
                backgroundColor = Brushes.Green;
                textColor = Brushes.Black;
            }
        }
        else
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = SystemBrushes.Highlight;
                textColor = SystemBrushes.HighlightText;
            }
            else
            {
                backgroundColor = SystemBrushes.Window;
                textColor = SystemBrushes.WindowText;
            }
        }
        e.Graphics.FillRectangle(backgroundColor, e.Bounds);
        e.Graphics.DrawString((sender as ComboBox).Items[e.Index].ToString(), font, textColor, e.Bounds);
    }
