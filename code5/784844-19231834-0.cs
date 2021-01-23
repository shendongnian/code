    public partial class frmPendulum : Form
    {
        private Timer timer;
        private Pendulum p = null;
        public frmPendulum()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmPendulum_Shown);
            this.Paint += new PaintEventHandler(frmPendulum_Paint);
        }
        void frmPendulum_Shown(object sender, EventArgs e)
        {
            p = new Pendulum(this.ClientRectangle.Width, this.ClientRectangle.Height);
            timer = new Timer() { Interval = 100 };
            timer.Tick += delegate(object s2, EventArgs e2)
            {
                this.Refresh();
            };
            timer.Start();
        }
        void frmPendulum_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.DrawPendulum(e.Graphics);
            }
        }
    }
    public class Pendulum
    {
        int length = 50;
        double angle = Math.PI / 2;
        double aAcc = -9.81;
        double aVel = 0;
        double gravity = 0.1;
        double mass = 0.2;
        int originX = 0;
        int originY = 0;
        int bobX; // = frmWidth / 2;
        int bobY; // = (int)length;
        Timer timer;
        public Pendulum(int frmWidth, int frmHeight)
        {
            timer = new Timer() { Interval = 50 };
            timer.Tick += delegate(object sender, EventArgs e)
            {
                originX = frmWidth / 2;
                originY = 0;
                //to be relative to origin we go:
                bobX = originX + (int)(Math.Sin(angle) * length);
                bobY = originY + (int)(Math.Cos(angle) * length);
                aAcc = -9.81 / length * Math.Sin(angle);
                aVel += aAcc * gravity * mass;
                angle += aVel * gravity; 
            };
            timer.Start();
        }
        public void DrawPendulum(Graphics G)
        {
            G.DrawLine(Pens.Black, originX, originY, bobX, bobY);
            G.FillEllipse(Brushes.Blue, bobX - 8, bobY, 20, 20); //-8 for tidyness!
        }
    }
