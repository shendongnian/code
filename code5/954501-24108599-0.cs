        class Animator : IDisposable {
            private Timer timer;
            private PictureBox pbox;
            private int maxSize;
            public Animator(PictureBox box, int size) {
                pbox = box;
                maxSize = size;
                timer = new Timer() { Interval = 45, Enabled = true };
                timer.Tick += animate;
            }
            private void animate(object sender, EventArgs e) {
                 if (pbox.IsDisposed || pbox.Width >= maxSize) Dispose();
                 else pbox.Width += Math.Min(2, maxSize - pbox.Width);
            }
            public void Dispose() { timer.Dispose();  }
        }
