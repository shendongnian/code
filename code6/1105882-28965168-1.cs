    public partial class Form1 : Form
    {
      public Form1()
      {
          InitializeComponent();
      }
      Form form2;
      Point MD = Point.Empty;
      Rectangle rect = Rectangle.Empty;
      private void button2_Click(object sender, EventArgs e)
      {
         Hide();
         form2 = new Form();
         form2.BackColor = Color.Wheat;
         form2.TransparencyKey = form2.BackColor;
         form2.ControlBox = false;
         form2.MaximizeBox = false;
         form2.MinimizeBox = false;
         form2.FormBorderStyle = FormBorderStyle.None;
         form2.WindowState = FormWindowState.Maximized;
         form2.MouseDown += form2_MouseDown;
         form2.MouseMove += form2_MouseMove;
         form2.Paint += form2_Paint;
         form2.MouseUp += form2_MouseUp;
 
         form2.Show();
     }
 
     void form2_MouseDown(object sender, MouseEventArgs e)
     {
         MD = e.Location;
     }
 
     void form2_MouseMove(object sender, MouseEventArgs e)
     {
         if (e.Button !=MouseButtons.Left) return;
         Point MM = e.Location;
         rect = new Rectangle(Math.Min(MD.X, MM.X), Math.Min(MD.Y, MM.Y),
                              Math.Abs(MD.X - MM.X), Math.Abs(MD.Y - MM.Y));
         form2.Invalidate();
     }
 
     void form2_Paint(object sender, PaintEventArgs e)
     {
         e.Graphics.DrawRectangle(Pens.Red, rect);
     }
 
      void form2_MouseUp(object sender, MouseEventArgs e)
      {
         form2.Hide();
         Screen scr = Screen.AllScreens[0];
         Bitmap bmp = new Bitmap(rect.Width, rect.Height);
         using (Graphics G = Graphics.FromImage(bmp))
         {
             G.CopyFromScreen(rect.Location, Point.Empty, rect.Size,
                              CopyPixelOperation.SourceCopy);
             pictureBox1.Image = bmp;
         }
         form2.Close();
         Show();
      }
 
    }
  
