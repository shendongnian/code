        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SetStyle(ControlStyles.ResizeRedraw, true); // this is important
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Rectangle rcBorder = e.ClipRectangle;
                rcBorder.Inflate(-10, -10); // just to accentuate with red colored border
                e.Graphics.DrawRectangle(Pens.Red, rcBorder); 
            }
        }
