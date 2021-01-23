    public partial class Form1 : Form
    {         
        int SystemWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int SystemHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private readonly double Ratio;
        private int oldWidth;
        private int oldHeight;
    
        public Form1()
        {               
            InitializeComponent();
    
            Ratio = (double)SystemWidth / SystemHeight;
            Size = new Size((int)(SystemWidth - 200 * Ratio), SystemHeight - 200);
        }
        protected override void OnResizeBegin(EventArgs e)
        {
            oldWidth = Width;
            oldHeight = Height;
            base.OnResizeBegin(e);
        }
        protected override void OnResize(EventArgs e)
        {
            int dw = Width - oldWidth;
            int dh = Height - oldHeight;
            if (dw > dh * Ratio)
                Width = (int)(oldWidth + dh * Ratio);
            else
                Height = (int)(oldHeight + dw / Ratio);
            base.OnResize(e);
        }
    }
