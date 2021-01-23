    //your form constructor
    public Form1(){
      InitializeComponent();
      //add string to the GraphicsPath, the string location is initialized with (10,10)
      gp.AddString("Your string goes here", Font.FontFamily, 
                  (int)Font.Style, 20, new Point(10, 10), StringFormat.GenericDefault);
    }
    GraphicsPath gp = new GraphicsPath();
    float dx, dy;
    //the Paint event handler for your pictureBox1
    private void pictureBox1_Paint(object sender, PaintEventArgs e) {
       e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;                
       gp.Transform(new Matrix(1, 0, 0, 1, dx, dy));//Translate and paint
       e.Graphics.FillPath(Brushes.Red, gp);
       gp.Transform(new Matrix(1,0,0,1,-dx,-dy));//translate back (reset to old location)
    }
    Point downPoint;
    bool hitOn;
    //MouseDown event handler for your pictureBox1
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e){
       if(e.Button == MouseButtons.Left){
           downPoint = e.Location; 
           if (gp.GetBounds(new Matrix(1,0,0,1,dx,dy)).Contains(e.Location)) {
             gp.Transform(new Matrix(1, 0, 0, 1, dx, dy));                
             hitOn = true;
           }
       }
    }
    //MouseMove event handler for your pictureBox1
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
       if (e.Button == MouseButtons.Left) {
         if(hitOn){
           dx = e.X - downPoint.X;
           dy = e.Y - downPoint.Y;
           pictureBox1.Invalidate();
         } else {
           pictureBox1.Left += e.X - downPoint.X;
           pictureBox1.Top += e.Y - downPoint.Y;
         }
       }
    }
    //MouseUp event handler for your pictureBox1
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
       hitOn = false;
    }
