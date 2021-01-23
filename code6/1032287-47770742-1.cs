    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            FullImage.ParentBoundry = new Size(this.Width, this.Height);
            // Enter the image path  
            FullImage.LoadImage(Image.FromFile(@"D:\a.jpg"));
        }
        //Create a paint event
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FullImage.Paint(e.Graphics);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Vault.FullImage.MouseDown(e.Location);
            this.Invalidate();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Vault.FullImage.MouseMove(e.Location);
            this.Invalidate();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Vault.FullImage.MouseUp(e.Location);
            this.Invalidate();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Vault.FullImage.MouseWheel(e.Delta);
            this.Invalidate();
        }
