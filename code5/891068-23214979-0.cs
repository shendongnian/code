    public partial class YourControl : Control
    {
        public YourControl()
        {
            InitializeComponent();
    
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
        }
