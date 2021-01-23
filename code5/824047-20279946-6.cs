    public partial class Form1 : Form
    {
        public Form1()
        {            
            InitializeComponent();
            var e = new Ellipse(new Point(400, 400), 100, 100) { Canvas = this };
            e.MouseEnter += (s, ev) => {
                e.BackColor = Color.Red;
            };
            e.MouseLeave += (s, ev) => {
                e.BackColor = Color.Green;
            };
            e.Click += (s, ev) => {
                e.Visible = false; //Hide the ellipse
            };
        }
    }
