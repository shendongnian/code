    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport(@"gdiplus.dll")]
        public static extern int GdipWindingModeOutline(HandleRef path, IntPtr matrix, float flatness);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(30, 40, 50, 200); 
            Rectangle rectangle2 = new Rectangle(30, 190, 200, 50);
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(rectangle1);
            gp.AddRectangle(rectangle2);
            HandleRef handle = new HandleRef(gp, (IntPtr)gp.GetType().GetField("nativePath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gp));
            GdipWindingModeOutline(handle, IntPtr.Zero, 0.25F);
            e.Graphics.DrawPath(Pens.Blue, gp);
        }
    }
