    public partial class Form1 : Form
    {
        private Panel panel1;
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
            panel1 = new Panel();
            SuspendLayout();
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.BackColor = Color.Black;
            panel1.Size = new System.Drawing.Size(322, 180);
            panel1.TabIndex = 0;
            panel1.MouseEnter += new EventHandler(MouseEnterLogic);
            panel1.MouseLeave += new EventHandler(MouseLeaveLogic);
            Controls.Add(panel1);
            ResumeLayout();
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
        private void MouseLeaveLogic(object sender, EventArgs e)
        {
            if (Cursor.Position.X > this.Location.X + this.Width - 10 || Cursor.Position.Y > this.Location.Y + this.Height - 10 || Cursor.Position.X < this.Location.X + 10 || Cursor.Position.Y < this.Location.Y + 30)
                mouse_over = false;
        }
        private void MouseEnterLogic(object sender, EventArgs e)
        {
            mouse_over = true;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            MouseLeaveLogic(this, e);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            MouseLeaveLogic(this, e);
            base.OnMouseEnter(e);
        }
    }
