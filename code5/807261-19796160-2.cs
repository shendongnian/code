        private const int AnimationSteps = 100;
        private const int AnimationStepSize = 4;
        private System.Windows.Forms.Timer _timer;
        private Bitmap _buffer;
        private int _animationStep = 0;
        public SpriteCanvas()
        {
            _buffer = new Bitmap(2000, 2000);
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 10;
            _timer.Tick += (s, e) =>
            {
                _animationStep++;
                if (_animationStep > AnimationSteps)
                    _animationStep = 0;
                this.Invalidate();
            };
            _timer.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(_buffer))
            {
                // draw sprites based on current _animationStep value
                // g.DrawImage(...)
            }
            e.Graphics.DrawImage(_buffer, new Rectangle(0, 0, _buffer.Width, _buffer.Height), new Rectangle(0, 0, _buffer.Width, _buffer.Height), GraphicsUnit.Pixel);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _timer.Dispose();
            _buffer.Dispose();
        }
    }
