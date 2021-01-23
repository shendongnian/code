    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV.UI;
    using Emgu.Util;
    namespace videosearch
    {
    public partial class detect : Form
    {
        int i = 0;
        bool blac = false;
        Image<Bgr, byte> imageorgnal;
        Image<Gray, byte> imgproc;
        string[] imagepath;
        
        public detect()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // to run all the image 
            if (blac == true)
            {
                Application.Idle -= procframdatGUI;
                blac = false;
                button1.Text = "Resume";
            }
            else
            {
                Application.Idle += procframdatGUI;
                button1.Text = "pause";
                blac = true;
            }
        }
        void procframdatGUI(object sender, EventArgs e)
        {
            if (imagepath != null)
            {
                Bitmap p = new Bitmap(imagepath[i]);
                p = comparePic.ResizeBitmap(p, 680, 480);
                imageorgnal = new Image<Bgr, byte>(p);
                i++; //incrce i for next iamge 
                if (i >= imagepath.Length)
                    i = 0;
                if (imageorgnal == null)
                    return;
                imgproc = imageorgnal.InRange(new Bgr(0, 0, 175), new Bgr(100, 100, 256));
                imgproc = imgproc.SmoothGaussian(9);
                CircleF[] cir = imgproc.HoughCircles(new Gray(100), new Gray(50), 5, imgproc.Height / 4, 10, 500)[0];
                foreach (CircleF ci in cir)
                {
                    if (textBox1.Text != "")
                    textBox1.AppendText(Environment.NewLine);
                    
                    textBox1.AppendText("ball position x=" + ci.Center.X.ToString().PadLeft(4) + "\n Y= " + ci.Center.Y.ToString().PadLeft(4) + "\n ridius" + ci.Radius.ToString("###.000").PadLeft(7));
                    textBox1.ScrollToCaret();
                    CvInvoke.Circle(imgproc, new Point((int)ci.Center.X, (int)ci.Center.Y), 3, new MCvScalar(0, 255, 0), -1, LineType.AntiAlias, 0);
                    imageorgnal.Draw(ci, new Bgr(Color.Red), 4);
                }
                imageBox1.Image = imageorgnal;
                imageBox2.Image = imgproc;
            }
            else
                MessageBox.Show("iamges haven't been selected");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //next image 
            procframdatGUI(null, null);
            blac = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //select images 
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            if (op.ShowDialog() != DialogResult.Cancel)
            {
                imagepath = new string[op.SafeFileNames.Length];
                imagepath = op.FileNames;
            }
        }
    }
    }
