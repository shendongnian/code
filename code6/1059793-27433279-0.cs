	using System;
	using System.Diagnostics;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Windows.Forms;
	namespace RotateImage {
		public partial class Form1 : Form {
			private readonly Graphics gfx;
			private readonly Bitmap originalBitmap;
			private readonly Bitmap redrawnBitmap;
			private readonly Stopwatch sw;
			private Timer timer;
			public Form1() {
				InitializeComponent();
				BackColor = Color.White;
				timer = new Timer();
				timer.Interval = 16;
				timer.Enabled = true;
				timer.Tick += timer_Tick;
				sw = new Stopwatch();
				sw.Start();
				gfx = CreateGraphics();
				originalBitmap = new Bitmap(256, 256);
				redrawnBitmap = new Bitmap(256, 256);
				using (var bmpGfx = Graphics.FromImage(originalBitmap)) {
					DrawCross(bmpGfx, new Point(128, 128), 128D, 0D);
				}
			}
			private void timer_Tick(object sender, EventArgs e) {
				// Rotate a full 90 degrees every 4 seconds.
				var angle = sw.Elapsed.TotalSeconds * 22.5D;
				var newBitmap = RotateImage(originalBitmap, (float)angle);
			
				// Clear the result of the last draw.
				gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, 256, 256));
				gfx.DrawImageUnscaled(newBitmap, 0, 0);
				gfx.DrawEllipse(Pens.Blue, new Rectangle(124, 124, 8, 8));
			
				using (var redrawGfx = Graphics.FromImage(redrawnBitmap)) {
					// Clear what we have, we are redrawing on the same surface.
					redrawGfx.Clear(Color.White);
					DrawCross(redrawGfx, new Point(128, 128), 128D, angle);
				}
				gfx.DrawImageUnscaled(redrawnBitmap, 256, 0);
				gfx.DrawEllipse(Pens.Blue, new Rectangle(256+124, 124, 8, 8));
			}
			private void DrawCross(Graphics drawGfx, Point center, double radius, double angle) {
				// Turn our angle from degrees to radians.
				angle *= Math.PI / 180;
				// NOTE: Using PointF to lazily "fix" rounding errors and casting (flooring) double to int. When the result of the math below is say 127.9999999...
				// then it would get rounded down to 127. There is always Math.Round, which can round to nearest whole (away from .5) integer!
				// Draw one line of our cross.
				drawGfx.DrawLine(
					Pens.Red,
					new PointF((float)(Math.Cos(angle) * radius + center.X), (float)(Math.Sin(angle) * radius + center.Y)),
					new PointF((float)(Math.Cos(angle - Math.PI) * radius + center.X), (float)(Math.Sin(angle - Math.PI) * radius + center.Y)));
				// Rotate our angle 90 degrees.
				angle += Math.PI / 2D;
				// Draw the other line of our cross.
				drawGfx.DrawLine(
					Pens.Red,
					new PointF((float)(Math.Cos(angle) * radius + center.X), (float)(Math.Sin(angle) * radius + center.Y)),
					new PointF((float)(Math.Cos(angle - Math.PI) * radius + center.X), (float)(Math.Sin(angle - Math.PI) * radius + center.Y)));
			}
			// Your method, not mine.
			private Bitmap RotateImage(Bitmap b, float angle)
			{
				//Create a new empty bitmap to hold rotated image.
				Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
				//Make a graphics object from the empty bitmap.
				Graphics g = Graphics.FromImage(returnBitmap);
				//move rotation point to center of image.
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.TranslateTransform((float) b.Width / 2, (float)b.Height / 2);
				//Rotate.        
				g.RotateTransform(angle);
				//Move image back.
				g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
				//Draw passed in image onto graphics object.
				g.DrawImage(b, new Point(0, 0));
				return returnBitmap;
			}
		}
	}
