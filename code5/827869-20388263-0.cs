    using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Windows.Forms;
	namespace PBoxes
	{
		public partial class Form1 : Form
		{
			private float xFactor, yFactor;
			List<PointF> points = new List<PointF>();
			public Form1()
			{
				InitializeComponent();
				xFactor = (float)pictureBox2.Width / pictureBox1.Width;
				yFactor = (float)pictureBox2.Height / pictureBox1.Height;
			}
			private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
			{
				points.Add(new PointF(e.X * xFactor, e.Y * yFactor));
				pictureBox2.Invalidate();
			}
			private void pictureBox2_Paint(object sender, PaintEventArgs e)
			{
				foreach (PointF pt in points)
				{
					e.Graphics.FillEllipse(Brushes.Red, pt.X, pt.Y, 3f, 3f);
				}
			}
			private void pictureBox_SizeChanged(object sender, EventArgs e)
			{
				xFactor = (float)pictureBox2.Width / pictureBox1.Width;
				yFactor = (float)pictureBox2.Height / pictureBox1.Height;
			}
		}
	}
