    public partial class difficultyForm : Form
    {
        string difficulty = "";
        public difficultyForm()
        {
            InitializeComponent();
        }
        public event Action<string> DifficultySubmitted;
        private void enterButton_Click(object sender, EventArgs e)
        {
            difficulty = difficultyTextBox.Text;
            if (DifficultySubmitted != null)
                DifficultySubmitted(difficulty);
            //...
        }
    }
