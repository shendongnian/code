    public partial class MainForm : Form
    {
        private Person _person;
        public MainForm(Person person)
        {
            InitializeComponent();
            _person = person;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            fooButton.Enabled = (_person.Position == JobPosition.Doctor);
            // etc
        } 
    }
