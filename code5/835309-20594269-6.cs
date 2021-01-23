    public partial class Form1 : Form
    {
        private byte ImageNumber = 20;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            ImageNumber-=1;
            if (MaxNumberOfImages < 1)
                return;
        
            string path = @"C:\Users\Ole-Jeger\Documents\Visual Studio 2013\Projects\Test_Spill1\Test_Spill1\Pictures\";
            Heathbar.Image = Image.FromFile(path + ImageNumber.ToString() + ".png");
        }
    }
