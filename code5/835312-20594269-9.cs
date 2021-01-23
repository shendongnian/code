    public partial class Form1 : Form
    {
        private const string path = 
            @"C:\Users\Ole-Jeger\Documents\Visual Studio 2013\Projects\Test_Spill1\Test_Spill1\Pictures\";
        private const int INT_ImageCount = 20;
        private int ImageNumber = INT_ImageCount;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (ImageNumber > 0)
            {
                ImageNumber -= 1;
                // How about disabling the button?
                if (ImageNumber == 0)
                {
                    button1.Enabled = false;
                }
            }
            /*else
            {
                // Bad boys, Bad boys,
                // whatcha gonna do?
                // whatcha gonna do?
                // whatcha gonna do when the number is nil?
                // Note: if you disabled the button, this shoudln't be a problem
            }*/
            Heathbar.Image = Image.FromFile(path + ImageNumber.ToString() + ".png");
        }
    }
