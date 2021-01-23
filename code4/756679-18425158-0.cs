    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point StartPoint, EndPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point pt = Cursor.Position;
                StartPoint = pt;
                EndPoint = pt;
                ControlPaint.DrawReversibleLine(StartPoint, EndPoint, Color.Black);
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ControlPaint.DrawReversibleLine(StartPoint, EndPoint, Color.Black); // erase previous line
                EndPoint = Cursor.Position;
                ControlPaint.DrawReversibleLine(StartPoint, EndPoint, Color.Black); // draw new line
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ControlPaint.DrawReversibleLine(StartPoint, EndPoint, Color.Black); // erase previous line
                // ... do something with StartPont and EndPoint in here ...
                // possibly add them to a class level structure to use in the Paint() event to make it persistent?
            }
        }
    }
