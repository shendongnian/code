    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(Properties.Resources.Background, 0, 0);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    e.Graphics.DrawImage(Properties.Resources.Pawn, new Rectangle(j * 57, i * 57, 52, 52));
        }
    }
