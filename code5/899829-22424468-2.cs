    public partial class PuzzleForm : Form
    {
        private readonly Image[,] Images;
        private readonly int Nx;
        private readonly int Ny;
        private int sourceIndexX;
        private int sourceIndexY;
        private int destinationIndexX;
        private int destinationIndexY;
        private PuzzleForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }
        public PuzzleForm(Image[,] images)
            : this()
        {
            Images = images;
            Nx = Images.GetLength(0);
            Ny = Images.GetLength(1);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                for (int j = 0; j < Ny; j++)
                    for (int i = 0; i < Nx; i++)
                    {
                        Rectangle rect = new Rectangle(ClientSize.Width * i / Nx, ClientSize.Height * j / Ny, ClientSize.Width / Nx - 1, ClientSize.Height / Ny - 1);
                        g.DrawImage(Images[i, j], rect);
                    }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left)
                return;
            sourceIndexX = e.X * Nx / ClientSize.Width;
            sourceIndexY = e.Y * Ny / ClientSize.Height;
            Cursor = Cursors.Hand;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left)
                return;
            destinationIndexX = e.X * Nx / ClientSize.Width;
            destinationIndexY = e.Y * Ny / ClientSize.Height;
            Cursor = Cursors.Default;
            MessageBox.Show(String.Format("From [{0}, {1}] to [{2}, {3}]", sourceIndexX, sourceIndexY, destinationIndexX, destinationIndexY));
        }
    }
