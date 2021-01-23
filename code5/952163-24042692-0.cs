    private void SetControlOnCell(ListView lv, Control eControl, MouseEventArgs e) {
        ListViewHitTestInfo lit = lv.HitTest(e.Location);
    
        Point p = new Point
        {
            X = lv.Left + lit.SubItem.Bounds.Left + 1,
            Y = lv.Top + lit.SubItem.Bounds.Top
        };
    
        int w = (lit.SubItem.Bounds.Left == 0) ? lv.Columns[0].Width : lit.SubItem.Bounds.Width;
        int h = lit.SubItem.Bounds.Height;
    
        eControl.Location = p;
        eControl.Size = new Size(w, h);
    
        if (!eControl.Visible) eControl.Visible = true;
        if (eControl.Font != lit.SubItem.Font) eControl.Font = lit.SubItem.Font;
        eControl.Text = lit.SubItem.Text;
        eControl.Focus();        
    }
