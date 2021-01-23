    public partial class Form1 : Form
    {
    	Boolean bHaveMouse;
    	Point ptOriginal = new Point();
    	Point ptLast = new Point();
    
    	public Form1()
    	{
    		InitializeComponent();
    
    		this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
    		this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
    		this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
    	}
    
    	private void MyDrawReversibleRectangle(Point p1, Point p2)
    	{
    		Bitmap myBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
    
    		using (Graphics g = Graphics.FromImage(myBitmap))
    		{
    			g.Clear(Color.Aqua);
    			g.DrawRectangle(new Pen(Brushes.Black), p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
    		}
    
    		this.pictureBox1.Image = myBitmap;
    	}
    
    	private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    	{
    		Point ptCurrent = new Point(e.X, e.Y);
    		if (bHaveMouse)
    		{
    			if (ptLast.X != -1)
    			{
    				MyDrawReversibleRectangle(ptOriginal, ptLast);
    			}
    			ptLast = ptCurrent;
    			MyDrawReversibleRectangle(ptOriginal, ptCurrent);
    		}
    
    	}
    
    	private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    	{
    		bHaveMouse = true;
    		ptOriginal.X = e.X;
    		ptOriginal.Y = e.Y;
    		ptLast.X = -1;
    		ptLast.Y = -1;
    	}
    
    	private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    	{
    		bHaveMouse = false;
    		if (ptLast.X != -1)
    		{
    			Point ptCurrent = new Point(e.X, e.Y);
    			MyDrawReversibleRectangle(ptOriginal, ptLast);
    		}
    		ptLast.X = -1;
    		ptLast.Y = -1;
    		ptOriginal.X = -1;
    		ptOriginal.Y = -1;
    	}
    }
