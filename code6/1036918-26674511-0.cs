     public partial class CircleControl : UserControl
    {
        private Random rnd = new Random();
        Pen p = new Pen(Color.Blue, 3);
        public CircleControl()
        {
            InitializeComponent();
            this.Paint += CircleControl_Paint;
                       
        }
        public void UpdateCircle() 
        {
            this.Invalidate();
        }
        void CircleControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            int randomInt = rnd.Next(0, 11);
            e.Graphics.DrawEllipse(p, new Rectangle(new Point(0, randomInt), this.Size));
        }
    }
