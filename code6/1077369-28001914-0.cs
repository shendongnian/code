      public partial class Form1 : Form
      {
        
        Bitmap img1 = Properties.Resources._1;
        Bitmap img2 =Properties.Resources._2;
        Bitmap img3 = Properties.Resources._3;
        Bitmap img4 = Properties.Resources._4;
        Bitmap img10 = Properties.Resources._10;
        Bitmap img1x = Properties.Resources._1x
        public Form1()
        {
            InitializeComponent();
            pb1.Image = img1; //assign image1 to picturebox here
            pb2.Image = img2; 
            pb3.Image = img3; 
            pb4.Image = img4; 
            pb10.Image = img10; 
        }
        private void pb1_Click(object sender, EventArgs e)
        {
           if (pb1.Image == img1)
           {
             pb1.Image = img1x ;
           }
           else { pb1.Image = img1; }
        }
      }
