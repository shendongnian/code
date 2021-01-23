    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        TabPage tp = tabControl1.TabPages[e.Index];
       using (SolidBrush brush = 
              new SolidBrush(tp.Enabled ? tp.BackColor : SystemColors.ControlLight))
       using (SolidBrush textBrush = 
              new SolidBrush(tp.Enabled ? tp.ForeColor : SystemColors.ControlDark))
        {
           e.Graphics.FillRectangle(brush, e.Bounds);
           e.Graphics.DrawString(tp.Text, e.Font, textBrush, e.Bounds.X + 3, e.Bounds.Y + 4);
        }
    }
