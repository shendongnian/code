    public partial class Form1 : Form {
      public Form1(){
            InitializeComponent();
            draggingPic.Location = pictureBox2.Location;
            draggingPic.Size = pictureBox2.Size;
            draggingPic.Parent = this;          
            draggingPic.BackgroundImage = pictureBox2.BackgroundImage;
            draggingPic.BackgroundImageLayout = pictureBox2.BackgroundImageLayout;
            draggingPic.BorderStyle = pictureBox2.BorderStyle;
            draggingPic.BringToFront();//This is important, your draggingPic should be on Top
            //MouseDown event handler for draggingPic
            draggingPic.MouseDown += (s, e) => {
                downPoint = e.Location;
            };
            //MouseMove event handler for draggingPic
            draggingPic.MouseMove += (s, e) => {
                if(e.Button == MouseButtons.Left){
                    draggingPic.Left += e.X - downPoint.X;
                    draggingPic.Top += e.Y - downPoint.Y;
                }
            };
            //MouseUp event handler for draggingPic
            draggingPic.MouseUp += (s, e) => {                
                g.DrawImage(draggingPic.BackgroundImage, new Rectangle(pictureBox1.PointToClient(draggingPic.PointToScreen(Point.Empty)), draggingPic.Size));
                draggingPic.Location = pictureBox2.Location;
            };
            //Initialize bm 
            //your pictureBox1 should have fixed Size during runtime
            //Otherwise we have to recreate bm in a SizeChanged event handler
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
            g = Graphics.FromImage(bm);
      }
      Bitmap bm;
      Graphics g;
      Point downPoint;
    }
