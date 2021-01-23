    public class MainForm : Form
    {
        private readonly IConfiguration _configuration;
    
        public MainViewModel(IConfiguration configuration)
        {
            InitializeControls();
            _configuration = configuration;
        }
    
        public void MakeAvailable(object sender, EventArgs e)
        {
            PictureBox.BackgroundImage = _configuration.AvailablePic;
        }
    
        public void MakeUnavailable(object sender, EventArgs e)
        {
            PictureBox.BackgroundImage = _configuration.UnavailablePic;
        }
    }
