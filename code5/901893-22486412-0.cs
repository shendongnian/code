    class MyToolStripMenuItem : ToolStripMenuItem
    {
        protected override void OnPaint( PaintEventargs pe )
        {
            base.OnPaint( pe );
            pe.ClipRectangle.Inflate( -1, -1 );
            pe.Graphics.DrawRectangle( Pens.Black, pe.ClipRectangle );
        }
    }
