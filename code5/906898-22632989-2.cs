    public partial class Form1 : Form
    {
    	Timer timer = new Timer();
    
    	int x;
    	int y;
    	public Form1()
    	{
    		InitializeComponent();
    		timer.Enabled = true;
    		timer.Interval = 100;  /* 100 millisec */
    		timer.Tick += new EventHandler(TimerCallback);
    	}
    	private void TimerCallback(object sender, EventArgs e)
    	{
    		x += 10;
    		y += 10;
    		this.Invalidate();
    		return;
    	}
    	protected override void OnPaint(PaintEventArgs e)
    	{
    		Graphics g = e.Graphics;
    		g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
    		g.FillRectangle(Brushes.Red, x, y, 100, 100);
    		base.OnPaint(e);
    	}
    }
