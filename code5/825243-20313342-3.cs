    public Form1(){
      InitializeComponent();
      label1.BackColor = Color.Transparent;
      label1.Parent = pictureBox1;
      //try this to prevent a little flicker, but looks like it does not help much
      typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                                 System.Reflection.BindingFlags.Instance)
                     .SetValue(pictureBox1, true, null);
    }
    Point lblDownPoint;
    //MouseDown event handler for your label1
    private void label1_MouseDown(object sender, MouseEventArgs e){
      if(e.Button == MouseButtons.Left) lblDownPoint = e.Location;
    }
    //MouseMove event handler for your label1
    private void label1_MouseMove(object sender, MouseEventArgs e){
      if(e.Button == MouseButtons.Left) {
        label1.Left += e.X - lblDownPoint.X;
        label2.Top += e.Y - lblDownPoint.Y;
      }
    }
