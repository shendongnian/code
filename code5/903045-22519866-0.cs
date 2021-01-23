      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          var blackPen = new Pen(Brushes.Black);
          for (int y = 0; y < 10; y++)
          {
            for (int x = 0; x < 10; x++)
            {
              e.Graphics.DrawLine(blackPen, new Point(x*20, y*20), new Point(x*20 + 10, y*20+10));
              e.Graphics.DrawLine(blackPen, new Point(x*20, y*20+10), new Point(x*20 + 10, y*20));
            }
          }
        }
      }
