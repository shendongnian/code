    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var gameTick = new Timer {Interval = 10};
            gameTick.Tick += (s, e) => BeginInvoke((Action)(Invalidate));
            gameTick.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            //calculate the scale ratio to fit a 320x200 box in the form
            var width = g.VisibleClipBounds.Width;
            var height = g.VisibleClipBounds.Height;
            var widthRatio = width / 320f;
            var heightRatio = height / 200f;
            var scaleRatio = Math.Min(widthRatio, heightRatio);
            g.ScaleTransform(scaleRatio, scaleRatio);
            //draw a 320x200 rectangle (because of scale transform this always fills form)
            g.FillRectangle(Brushes.Gray, 0, 0, 320, 200);
        }
    }
