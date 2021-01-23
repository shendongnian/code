    // at the beginning of your class declare an offscreen buffer
    private System.Drawing.Bitmap buffer;
    // .. later create it in the constructor
    public Form1() {
      InitializeComponent();
      // use the w/h of the picture box here
      buffer = new System.Drawing.Bitmap(picBox.Width, picBox.Height);
    }
    // in the designer add a paint event for the picture box:
    private picBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
       e.Graphics.DrawImageUnscaled(buffer);
    }
    // finally, your slightly modified painting routine...
    private picBox__MouseMove(object sender, MouseEventArgs e)
    {
      if (draw)
      {
        using (var context = System.Drawing.Graphics.FromImage(buffer)) {
          //create a brush:
          SolidBrush MysolidBrush = new SolidBrush(Color.Red);
          graphics.FillEllipse(MysolidBrush, e.X, e.Y,
                        Convert.ToInt32(toolStripTextBox1.Text),
                        Convert.ToInt32(toolStripTextBox1.Text));
        }
      }
    }
