    public partial class Form1 : Form
        {
            private Image<Bgr, Byte> imgStat = null;
            private Capture capture = null;
            private bool _captureInProgress = false;
         //   private bool captureInProgress;
     
            public Form1()
            {
                InitializeComponent();
                imgStat = null;
             }
     
            public string selectFile()
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                String s = ofd.FileName.Normalize();
                return s;
            }
             
            private void button2_Click(object sender, EventArgs e)
            {
                this.capture = new Capture(selectFile());                    
                capture.ImageGrabbed += ProcessFrame;
                capture.Start();
            }
     
            private void ProcessFrame(object sender, EventArgs e)
            {
                try
                {
                    //capture.Grab(); //doesnt help
                   // Image<Bgr, byte> beeldje = capture.QueryFrame(); //doesnt work as well
                    Image<Bgr, byte> beeldje = capture.RetrieveBgrFrame();
                   
                        DisplayImage(beeldje.ToBitmap());
                }
                catch (Exception er)
                {
                   Console.WriteLine(er.Message);
                }
            }
     
             private delegate void DisplayImageDelegate(Bitmap Image);
             private void DisplayImage(Bitmap Image)
             {
                 if (pictureBox1.InvokeRequired)
                 {
                     try
                     {
                         DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                         this.BeginInvoke(DI, new object[] {Image});
                     }
                     catch (Exception ex)
                     {
                     }
                 }
                 else
                 {
                     pictureBox1.Image = Image;
                 }
             }
        }
    }
