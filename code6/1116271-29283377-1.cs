    private Point? downPoint;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        downPoint = this.PointToClient(MousePosition);
        Cursor.Hide();
        base.OnMouseDown(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (downPoint.HasValue)
        {
            Cursor.Show();
        }
        downPoint = null;
        base.OnMouseUp(e);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (downPoint.HasValue)
        {
            Cursor.Draw(e.Graphics, new Rectangle(downPoint.Value, Cursor.Size));
        }
    }
