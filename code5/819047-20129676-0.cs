    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
        }
        private void MainMenu_Shown(object sender, EventArgs e)
        {
            Log_In login = new Log_In();
            login.Show();
            login.Activate();
        }
    }
