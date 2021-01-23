    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("You get 1 cookie for logging in!");
            setScore();
            score = Convert.ToInt32(setScr) + 1;
            label2.Text = score.ToString();
            setProgressBar(CheckMP());
            timer1.Interval = 1500;
            timer1.Start();
            //Assuming this is the first use of the Achievements object.
            Achievements.AchievementsFile = "achievements.txt";
        }
    }
        
