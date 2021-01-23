    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            System.Media.SoundPlayer player;
    
            public Form1()
            {
                InitializeComponent();
                string success = @"C:\Windows\Media\Windows Battery Critical.wav";
                string fail = @"C:\Windows\Media\Sonata\Windows Battery Critical.wav";
                player = new System.Media.SoundPlayer(success);
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                player.Play();
            }
        }
    }
