    internal class ToolText : ToolObject
    {
    public ToolText()
    {
    	Cursor = new Cursor(GetType(), "Rectangle.cur");
    }
    public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
    {
    	Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
    TextDialog td = new TextDialog();
    td.Location = new Point(e.X, e.Y + drawArea.Top + td.Height);
        if (td.ShowDialog() ==
        DialogResult.OK)
        {
        string t = td.TheText;
        Color c = td.TheColor;
        Font f = td.TheFont;
        AddNewObject(drawArea, new DrawText(p.X, p.Y, t, f, c));
        }
    }
