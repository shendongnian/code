	public partial class Form1 : Form
	{
		private Bitmap bitmap;
		private Random random = new Random();
		public Form1()
		{
			InitializeComponent();
			bitmap = new Bitmap(panel1.Width,panel1.Height);
		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(bitmap,new Point(0,0));
		}
		private void button1_Click(object sender, EventArgs e)
		{
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				
				graphics.DrawLine(
					new Pen(new SolidBrush(Color.Black),1),
					new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Width)),
					new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Width)));
				
			}
			panel1.Invalidate(); // redraw
		}
	}
