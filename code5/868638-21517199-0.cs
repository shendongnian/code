    if (!e.Index < 0)
    {
    e.DrawBackground();
    Graphics g = e.Graphics;
    Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? bg : new SolidBrush(e.BackColor);
    g.FillRectangle(brush, e.Bounds);
    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
    e.DrawFocusRectangle();
    }
