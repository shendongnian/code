    public partial class PersonDetailsForm : Form
    {
        public PersonDetailsForm(Person person)
        {
            InitializeComponent();
            nameTextBox.Text = person.Name;
            // etc
        }
    }
