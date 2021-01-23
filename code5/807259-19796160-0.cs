    public class SpriteCanvas : Control
    {
        private Bitmap _buffer = new Bitmap(2000, 2000);
        public int AnimationStep { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(_buffer))
            {
                // draw sprites
            }
            e.Graphics.DrawImage(_buffer, new Rectangle(0, 0, _buffer.Width, _buffer.Height), new Rectangle(0, 0, _buffer.Width, _buffer.Height), GraphicsUnit.Pixel);
        }
    }
