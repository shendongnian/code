    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player; //Note that they are created here
        System.Media.SoundPlayer player2; //They will be visible to the entire class
        bool keyPressed;
        public Form1()
        {
            InitializeComponent();
        }
        private void gameSounds()
        {
            if (!keyPressed) //Note that these Booleans are either true/false no need to compare to true or false
            {
                player = new System.Media.SoundPlayer(@"C:\Users\Parker\Desktop\Game\car_still.wav");
                player.PlayLooping();
            }
            else //this will be run if keypressed is true
            {
                player2 = new System.Media.SoundPlayer(@"C:\Users\Parker\Desktop\Game\car_speeding.wav");
                player2.PlayLooping();
                if(player != null) 
                    player.Stop(); 
            }
        }
    }
