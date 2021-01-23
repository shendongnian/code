    private void TreeViewControl_DrawNode(Object sender, DrawTreeNodeEventArgs e)
    {
    	//What might seem like strange positioning/offset is to ensure that our custom drawing falls in
    	//  line with where the base drawing would appear.  Otherwise, click handlers (hit tests) fail 
    	//  to register properly if our custom-drawn checkbox doesn't fall within the expected coordinates.
    
    	Int32 boxSize = 16;
    	Int32 offset = e.Node.Parent == null ? 3 : 21;
    	Rectangle bounds = new Rectangle(new Point(e.Bounds.X + offset, e.Bounds.Y + 1), new Size(boxSize, boxSize));
    	ControlPaint.DrawCheckBox(e.Graphics, bounds, e.Node.Checked ? ButtonState.Checked : ButtonState.Normal);
    	if (e.Node.Parent != null)
    	{
    		Color c = Color.Black;
    		String typeName = e.Node.Name.Remove(0, 4);
    		Object o = Enum.Parse(typeof(CalendarDataProvider.CalendarDataItemType), typeName);
    		if (o != null && (o is CalendarDataProvider.CalendarDataItemType))
    			c = CalendarDataProvider.GetItemTypeColor((CalendarDataProvider.CalendarDataItemType)o);
    		bounds = new Rectangle(new Point(bounds.X + boxSize + 2, e.Bounds.Y + 1), new Size(13, 13));
    		using (SolidBrush b = new SolidBrush(c))
    			e.Graphics.FillRectangle(b, bounds);
    		e.Graphics.DrawRectangle(Pens.Black, bounds);
    		e.Graphics.DrawLine(Pens.Black, new Point(bounds.X + 1, bounds.Bottom + 1), new Point(bounds.Right + 1, bounds.Bottom + 1));
    		e.Graphics.DrawLine(Pens.Black, new Point(bounds.Right + 1, bounds.Y + 1), new Point(bounds.Right + 1, bounds.Bottom + 1));
    	}
    	Font font = new Font("Microsoft Sans Serif", 9f, e.Node.Parent == null ? FontStyle.Bold : FontStyle.Regular);
    	bounds = new Rectangle(new Point(bounds.X + boxSize + 2, e.Bounds.Y), new Size(e.Bounds.Width - offset - 2, boxSize));
    	e.Graphics.DrawString(e.Node.Text, font, Brushes.Black, bounds);
    }
