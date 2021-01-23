	[System.ComponentModel.DesignerCategory("Code")]
	public class MyPanel : Panel
	{
		public MyPanel() 
		{
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
		protected override void OnPaint(PaintEventArgs e)
		{
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(Pens.Yellow, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
