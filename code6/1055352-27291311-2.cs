    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        SolidBrush brush = null;
        if (listBox1.Items[e.Index].ToString() != itemToColor )
                brush = new SolidBrush(e.ForeColor);
        else brush = new SolidBrush(Color.Red);
        {
            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), 
                                    e.Font, brush, new PointF(e.Bounds.X, e.Bounds.Y));
        }
    }
