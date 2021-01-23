        public partial class Form1 : Form
       {
           public Form1()
           {
            InitializeComponent();
             }
            private void button1_Click(object sender, System.EventArgs e)
            {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JPEG|*.jpg|PNG|*.PNG";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image image = Image.FromFile(dialog.FileName);
                    pictureBox1.Image = image;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        struct parameter
        {
            public float alpha { get; set; }
            public float beta { get; set; }
            public float gamma { get; set; }
        };
        unsafe private void button3_Click(object sender, EventArgs e)
        {
            {
                
            int length = 1000;
            Point *contour;
            
            Point center = new Point();
            var snake_param = new List<parameter>();
                snake_param.Add(new parameter { alpha=  0.1f , beta = 0.1f, gamma= 0.1f, });
            
            IntPtr dst_img= new IntPtr();
            
            Bitmap bitmap = new Bitmap("pictureBox1.Image");
            Image<Bgr, byte> image = new Image<Bgr, byte>(bitmap);
            
            center.X = image.Width;
            center.Y = image.Height;
                  
             
            
            
            int i;
            for (i = 0; i < length; i++)
            {
                contour[i].X = (int)(center.X * Math.Cos(2 * Math.PI * i / length) + center.X);
                contour[i].Y = (int)(center.Y * Math.Sin(2 * Math.PI * i / length) + center.Y);
            }
         LINE_TYPE lignetype = new LINE_TYPE();         
         
                
            for (i = 0; i < length - 1; i++)
            {
                CvInvoke.cvLine(
                    dst_img,
                    contour[i],
                    contour[i + 1],
                    new MCvScalar(255,0,0),
                    2, 
                    LINE_TYPE.EIGHT_CONNECTED,
                    0  );
            }
            CvInvoke.cvLine
                (
                dst_img,
                contour[length - 1],
                contour[0],
                new MCvScalar(255,0,0),
                2,
                LINE_TYPE.EIGHT_CONNECTED,
                0
                );
               IntPtr ctr =new IntPtr();
               //public void PixelToInkSpace(
                //IntPtr a 
                //ref Point contour
                //);          
               
            IntPtr src_img = image.Ptr;
            CvInvoke.cvSnakeImage(
                src_img,
                contour[i],
                length, 
                snake_param.[1].alfa,
                snake_param[2].beta,
                snake_param[3].gamma,
                1,
                new System.Drawing.Size(15, 15), 
                new MCvTermCriteria(1,0.0),
                1);
         
            CvInvoke.cvCvtColor(
                src_img,
                dst_img,
                COLOR_CONVERSION.GRAY2RGB );
            
                             
                for (i = 0; i < length - 1; i++)
            {
                CvInvoke.cvLine(
                    dst_img,
                    contour[i],
                    contour[i + 1],
                    new MCvScalar(255,0,0),
                    2, 
                    LINE_TYPE.EIGHT_CONNECTED,
                    0 );
            }
                CvInvoke.cvLine(
                    dst_img, 
                    contour[length - 1],
                    contour[0], 
                    new MCvScalar(255,0,0),
                        2, 
                        LINE_TYPE.EIGHT_CONNECTED,
                        0);
                 pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                 Bitmap bitmappbb = new Bitmap("dst_img");
                 Image<Bgr, byte> imagee = new Image<Bgr, byte>(bitmappbb);
                 pictureBox2.Image = bitmappbb;
                 }
       
              }
           }
       }
