    public partial class Form1 : Form
    {
        private const string path = 
            @"C:\Users\Ole-Jeger\Documents\Visual Studio 2013\Projects\Test_Spill1\Test_Spill1\Pictures\";
        private const int INT_MaxImage = 20;
        private int ImageNumber = INT_MaxImage;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (ImageNumber == 0)
            {
                 // Bad boys, Bad boys,
                 // whatcha gonna do?
                 // whatcha gonna do?
                 // whatcha gonna do when the number is nil?
            }
            else
            {
                ImageNumber -= 1;
                Heathbar.Image = Image.FromFile(path + ImageNumber.ToString() + ".png");
            }
        }
    }
