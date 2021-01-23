    public partial class MyForm : Form
    {
        private int ImagePosition = 0;
        private string[] arr1 = new string[] { "water", "eat", "bath", "tv", "park", "sleep" };
        private void button1_Click(object sender, EventArgs e)
        {
            ImagePosition = 0;
            RotateImage();
            Timer1.Start();      
        }
        private void RotateImage()
        {
            button1.BackgroundImage = 
            (Image)Properties.Resources.ResourceManager.GetObject(arr1[ImagePosition]);
            new SoundPlayer(Properties.Resources.nero).Play();
            ImagePosition++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ImagePosition > 5)
            {
                timer1.Enabled = false;
                return;
            }
            RotateImage();
        }
    }
