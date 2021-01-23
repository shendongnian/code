    //Must add using System.Runtime.InteropServices;
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            //Sizing border initialization
            SizingBorderWidth = 3;
            SizingBorderStyle = DashStyle.Custom;
            SizingBorderColor = Color.Orange;
            //layer initialization
            layer.Owner = this;//especially this one.
            layer.Width = Width + SizingBorderWidth * 2;
            layer.Height = Height + SizingBorderWidth * 2;                         
            //Paint the border when sizing
            layer.Paint += (s, e) => {
                using (Pen p = new Pen(SizingBorderColor) { Width = SizingBorderWidth }) {
                    if (Use3DSizingBorder) {
                        ControlPaint.DrawBorder3D(e.Graphics, sizingRect.Left, sizingRect.Top, sizingRect.Width, sizingRect.Height, Border3DStyle.Bump, Border3DSide.All);
                    }
                    else {
                        p.DashStyle = SizingBorderStyle;
                        p.LineJoin = LineJoin.Round;
                        if(p.DashStyle == DashStyle.Custom)
                           p.DashPattern = new float[] { 8f, 1f, 1f, 1f };//length of each dash from right to left
                        e.Graphics.DrawRectangle(p, sizingRect);
                    }
                }
            };
            //Bind the Location of the main form and the layer form together
            LocationChanged += (s, e) => {
                Point p = Location;
                p.Offset(-SizingBorderWidth, -SizingBorderWidth);
                layer.Location = p;
            };
            //Set the intial Location of layer
            Load += (s, e) =>{                
                Point p = Location;
                p.Offset(-SizingBorderWidth, -SizingBorderWidth);
                layer.Location = p;
            };            
        }
        //Set this to true to use 3D indicative/preview border
        public bool Use3DSizingBorder { get; set; }
        //Change the indicative/preview border thickness
        public int SizingBorderWidth { get; set; }
        //Change the indicative/preview border style
        public DashStyle SizingBorderStyle { get; set; }
        //Change the indicative/preview border color
        public Color SizingBorderColor { get; set; }
        //hold the current sizing Rectangle
        Rectangle sizingRect;
        bool startSizing;
        bool suppressSizing;
        //This is a Win32 RECT struct (don't use Rectangle)
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x214&&!suppressSizing)//WM_SIZING = 0x214
            {                
                RECT rect = (RECT) m.GetLParam(typeof(RECT));
                int w = rect.right - rect.left;
                int h = rect.bottom - rect.top;
                sizingRect = new Rectangle() {X = SizingBorderWidth/2, Y = SizingBorderWidth/2, 
                                              Width = w, Height = h};
                layer.Left = rect.left-SizingBorderWidth;
                layer.Top = rect.top-SizingBorderWidth;
                layer.Width = w+2*SizingBorderWidth;
                layer.Height = h+2*SizingBorderWidth;
                if (!startSizing)
                {
                    layer.Show();
                    startSizing = true;
                }
                layer.Invalidate();
                //Keep the current position and size fixed
                rect.right = Right;
                rect.bottom = Bottom;
                rect.top = Top;
                rect.left = Left;
                //---------------------------
                Marshal.StructureToPtr(rect, m.LParam, true);
            }
            if (m.Msg == 0x232)//WM_EXITSIZEMOVE = 0x232
            {
                layer.Visible = false;
                BeginInvoke((Action)(() => {
                    suppressSizing = true;
                    Left = layer.Left + SizingBorderWidth;
                    Top = layer.Top + SizingBorderWidth;
                    Width = layer.Width - 2 * SizingBorderWidth;
                    Height = layer.Height - SizingBorderWidth * 2;
                    suppressSizing = false;
                }));
                startSizing = false;
            }
            base.WndProc(ref m);            
        }
        //Here is the layer I mentioned before.
        NoActivationForm layer = new NoActivationForm();
    }    
    public class NoActivationForm : Form {
        public NoActivationForm() {
            //The following initialization is very important
            TransparencyKey = BackColor;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;            
            //----------------------------------------------                          
        }
        protected override bool ShowWithoutActivation {
            get { return true; }
        }
    }
