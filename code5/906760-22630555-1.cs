    [DefaultEvent("Click")]
    public partial class Sample : UserControl
    {
    	private string _text;
    	[Browsable(true)]
    	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    	public override string Text
    	{
    		get
    		{
    			return _text;
    		}
    		set
    		{
    			_text = value;
    		}
    	}
    	private bool _mouseDown = false;
    	private bool _mouseHover = false;
    	private bool _invalidateRequired = true;
    
    	public Sample()
    	{
    		InitializeComponent();
    	}
    	protected override void OnMouseDown(MouseEventArgs e)
    	{
    		base.OnMouseDown(e);
    		_mouseDown = true;
    		_invalidateRequired = true;
    		this.Invalidate();
    	}
    	protected override void OnMouseUp(MouseEventArgs e)
    	{
    		base.OnMouseUp(e);
    		_mouseDown = false;
    		_invalidateRequired = true;
    		this.Invalidate();
    	}
    	protected override void OnMouseMove(MouseEventArgs e)
    	{
    		base.OnMouseMove(e);
    		_mouseHover = true;
    		if (_invalidateRequired)
    		{
    			this.Invalidate();
    			_invalidateRequired = false;
    		}
    	}
    	protected override void OnMouseLeave(EventArgs e)
    	{
    		base.OnMouseLeave(e);
    		_mouseHover = false;
    		
    		this.Invalidate();
    		_invalidateRequired = true;
    	}
    	protected override void OnPaint(PaintEventArgs e)
    	{
    		base.OnPaint(e);
    		Rectangle r = new Rectangle(0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
    		Color bg = Color.White;
    		Color fr = Color.Gray;
    		Color br = Color.FromArgb(173, 178, 173);
    		if (_mouseDown)
    		{
    			bg = Color.FromArgb(24, 162, 231);
    			fr = Color.White;
    		}
    		if (_mouseHover)
    			br = Color.FromArgb(24, 162, 231);
    		e.Graphics.FillRectangle(new SolidBrush(bg), r);
    		e.Graphics.DrawRectangle(new Pen(br, 3), r);
    		StringFormat sf = new StringFormat();
    		sf.LineAlignment = StringAlignment.Center;
    		sf.Alignment = StringAlignment.Center;
    		e.Graphics.DrawString(Text, this.Font, new SolidBrush(fr), r, sf);            
    	}
    }
