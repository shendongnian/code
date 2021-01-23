	public class Form1 : Form {
		Button btn = new Button { Text = "Button", Dock = DockStyle.Top };
		AsyncPictureBox box = new AsyncPictureBox("c:\\temp\\chick_dance.gif") { Dock = DockStyle.Fill };
		public Form1() {
			Controls.Add(box);
			Controls.Add(btn);
			btn.Click += delegate {
				box.AnimateImage = !box.AnimateImage;
				Thread.Sleep(30000);
			};
		}
	}
	public class AsyncPictureBox : Control {
		Bitmap bitmap = null;
		bool currentlyAnimating = false;
		int frameCount = 0;
		int frame = 0;
		public AsyncPictureBox(String filename) {
			bitmap = new Bitmap(filename);
			this.DoubleBuffered = true;
			frameCount = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);
		}
		public bool AnimateImage {
			get {
				return currentlyAnimating;
			}
			set {
				if (currentlyAnimating == value)
					return;
				currentlyAnimating = value;
				if (value)
					ImageAnimator.Animate(bitmap, OnFrameChanged);
				else
					ImageAnimator.StopAnimate(bitmap, OnFrameChanged);
			}
		}
		// even though the UI thread is busy, this event is still fired
		private void OnFrameChanged(object o, EventArgs e) {
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, frame);
			frame = (frame + 1) % frameCount;
			g.DrawImage(bitmap, Point.Empty);
			g.Dispose();
		}
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
			if (disposing) {
				if (bitmap != null)
					bitmap.Dispose();
				bitmap = null;
			}
		}
	}
