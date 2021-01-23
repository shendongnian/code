    public partial class Form1 : Form
    {
        private Timer timer;
        private double opacity_increment;
        private bool mouse_over;
        public Form1()
        {
            InitializeComponent();
            opacity_increment = 0.1d;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mouse_over)
            {
                if (Opacity <= 1)
                {
                    Opacity += opacity_increment;
                }
            }
            else
            {
                if (Opacity >= 0.5d)
                {
                    Opacity -= opacity_increment;
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            mouse_over = true;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mouse_over = false;
            base.OnMouseEnter(e);
        }
    }
