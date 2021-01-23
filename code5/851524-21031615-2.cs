    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            _stopwatch.Start();
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            const float rotationTime = 2000f;
            var elapsedTime = (float) _stopwatch.ElapsedMilliseconds;
            var swingRadius = Math.Min(ClientSize.Width, ClientSize.Height) / 4f;
            var theta = Math.PI * 2f * elapsedTime / rotationTime;
            var ballRadius = Math.Min(ClientSize.Width, ClientSize.Height) / 10f;
            var ballCenterX = (float) ((ClientSize.Width / 2f) + (swingRadius * Math.Cos(theta)));
            var ballCenterY = (float) ((ClientSize.Height / 2f) + (swingRadius * Math.Sin(theta)));
            var ballLeft = ballCenterX - ballRadius;
            var ballTop = ballCenterY - ballRadius;
            var ballWidth = ballRadius * 2f;
            var ballHeight = ballRadius * 2f;
            e.Graphics.FillEllipse(Brushes.Red, ballLeft, ballTop, ballWidth, ballHeight);
            e.Graphics.DrawEllipse(Pens.Black, ballLeft, ballTop, ballWidth, ballHeight);
        }
        private readonly Stopwatch _stopwatch = new Stopwatch();
    }
