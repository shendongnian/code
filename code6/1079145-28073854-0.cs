    public class UserInformation
    {
        public static int Value
        {
            get;
            set;
        }
    }
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            this.timer1.Interval = SystemManager.RandomNumberGenerator(1000, 2000);
            this.timer1.Tick += new EventHandler(this.CheckTimer);
        }
        private void Loading_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
        private void CheckTimer(object sender, EventArgs e)
        {
            uint timeLeft = 1;
            timeLeft--;
            if (timeLeft == 0)
            {
                this.timer1.Stop();
                this.Hide();
                switch (UserInformation.Value)
                {
                    case 0:
                    AgeConfirmation _ageConfirmation = new AgeConfirmation();
                    _ageConfirmation.ShowDialog();
                    break;
                    case 1:
                    MainForm _mainForm = new MainForm();
                    _mainForm.ShowDialog();
                    break;
                    case 2:
                    Event _event = new Event();
                    _event.ShowDialog();
                    break;
                }
                this.Close();
            }
        }
    }
    private void AgeConfirmation_Load(object sender, EventArgs e)
        {
            UserInformation.Value = 1;
        }
    private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loading _loading = new Loading();
            _loading.ShowDialog();
            this.Close();
        }
    private void MainForm_Load(object sender, EventArgs e)
        {
            UserInformation.Value = 2;
        }
    private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loading _loading = new Loading();
            _loading.ShowDialog();
            this.Close();
        }
