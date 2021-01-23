     bool selected = e.Item.Selected;
     using ( SolidBrush backBrush = new SolidBrush( 
             selected? SystemColors.MenuHighlight :SystemColors.Window ) )
        e.Graphics.FillRectangle(backBrush, e.Bounds);
     using (SolidBrush textBrush = new SolidBrush(
             selected ? Color.White : Color.Black        ))
        e.Graphics.DrawString(e.Item.Text, yourFont, textBrush, e.Bounds.X, e.Bounds.Y);
