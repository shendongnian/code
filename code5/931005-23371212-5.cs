    public partial class Form1 : Form
    {
        private Point pos = new Point(1,1);
        private float[] vel = new float[2];
        private Size bounds = new Size(20,20);
        private Timer ticky = new Timer();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ticky.Interval = 20;
            ticky.Tick += ticky_Tick;
            vel[0] = 4; vel[1] = 0;
            ticky.Start();
        }
        void ticky_Tick(object sender, EventArgs e)
        {
            updatePosition();
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(new SolidBrush(Color.LightBlue), new Rectangle(pos, bounds));
        }
        private void updatePosition()
        {
            pos = new Point(pos.X + (int)vel[0], pos.Y + (int)vel[1]);
            vel[1] += .5f; //Apply some gravity
            if (pos.X + bounds.Width > this.ClientSize.Width)
            {
                vel[0] *= -1;
                pos.X = this.ClientSize.Width - bounds.Width;
            }
            if (pos.X < 0)
            {
                vel[0] *= -1;
                pos.X = 0;
            }
            if (pos.Y + bounds.Height > this.ClientSize.Height)
            {
                vel[1] *= -.90f; //Lose some velocity when bouncing off the ground
                pos.Y = this.ClientSize.Height - bounds.Height;
            }
            if (pos.Y < 0)
            {
                vel[1] *= -1;
                pos.Y = 0;
            }
        }
    }
