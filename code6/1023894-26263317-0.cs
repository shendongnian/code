    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        //A using statement on the brush will make sure it is disposed.
        using (var b1 = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Red))
        {
            PointF[] points = methodThatReturnsPointsForAPolygon();
            e.Graphics.FillPolygon(b1, points);
        }
    }
