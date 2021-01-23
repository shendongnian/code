    public partial class Form1 : Form
    {
        private const byte MaxNumberOfImages = 20;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MaxNumberOfImages -=1;
            if (MaxNumberOfImages < 0)
                throw new Exception("Implement logic here!")   
        string path = @"C:\Users\Ole-Jeger\Documents\Visual Studio 2013\Projects\Test_Spill1\Test_Spill1\Pictures\";
            //Heathbar.Image = Image.FromFile(path + r.Next(20).ToString() + ".png");
            Heathbar.Image = Image.FromFile(path +)
        }
    }
