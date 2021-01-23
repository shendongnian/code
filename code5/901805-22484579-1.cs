        private partial class AchievementsForm : Form
        {
            public AchievementsForm()
            {
                InitializeComponent();
            }
            private void Achievements_Load(object sender, EventArgs e)
            {
                IEnumerable<string> allAchievements = Achievements.ReadAchievements();
                //Do stuff with the achievements
            }
        }
