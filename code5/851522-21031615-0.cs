    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            const float rotationTime = 2000;
            float elapsedTime = _stopwatch.ElapsedMilliseconds;
            float swingRadius = Math.Min(ClientSize.Width, ClientSize.Height) / 4f;
            float theta = ((elapsedTime%rotationTime) / rotationTime) *Math.PI*2f;
            float ballRadius = Math.Min(ClientSize.Width, ClientSize.Height) / 10f;
            float ballCenterX = (float)((ClientSize.Width / 2f) + (swingRadius * Math.Cos(theta))) - (ballRadius / 2f);
            float ballCenterY = (float)((ClientSize.Height / 2f) + (swingRadius * Math.Sin(theta))) - (ballRadius / 2f);
            e.Graphics.FillEllipse(Brushes.Red, ballCenterX, ballCenterY, ballRadius, ballRadius);
            e.Graphics.DrawEllipse(Pens.Black, ballCenterX, ballCenterY, ballRadius, ballRadius);
        }
        private readonly Stopwatch _stopwatch = new Stopwatch();
    }
