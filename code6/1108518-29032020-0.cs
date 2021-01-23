	this.SetStyle(
		ControlStyles.ResizeRedraw | 
		ControlStyles.OptimizedDoubleBuffer | 
		ControlStyles.AllPaintingInWmPaint |
		ControlStyles.SupportsTransparentBackColor |
		ControlStyles.UserPaint, true);
	this.BackColor = Color.Transparent;
	protected override void OnPaint(PaintEventArgs e)
	{
		// TODO: Draw the button here
		base.OnPaint(e);
	}
