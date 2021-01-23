    public partial class PersonDetailsForm : Form
    {
        public PersonEditForm(Person person)
        {
            InitializeComponent();
            idLabel.Text = person.Id.ToString();
            nameTextBox.Text = person.Name;
            // etc
        }
        public Person Person
        {
            return new Person {
                Id = Int32.Parse(idLabel.Text),
                Name = nameTextBox.Text
            };
        }     
    }
