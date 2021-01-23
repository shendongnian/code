        private Point loc;
        public Form2(Point location)
        {
            InitializeComponent();
            loc = location;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(loc.X, loc.Y);
        }
