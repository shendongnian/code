	public partial class Form1 : Form
	{
		public Bitmap Foreground;
		public Form1()
		{
			InitializeComponent();
			
			// Create foreground buffer same size as picture box
			Foreground = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
			// Draw a blue ellipse in the foreground buffer for something to see
			using (var g = Graphics.FromImage(Foreground))
			{
				g.Clear(Color.Transparent);
				g.DrawEllipse(Pens.Blue, 10, 10, 300, 100);
			}
		}
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(Foreground, 0, 0);
		}
	}
