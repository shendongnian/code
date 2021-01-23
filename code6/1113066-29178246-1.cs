    // your form
    public partial class Form1 : Form
    {
        // the property contains all the items that will be shown in the combobox
        protected IList<DataStructure> dataItems = new BindingList<DataStructure>();
        // a way to keep the selected reference that you do not always have to ask the combobox, gets updated on selection changed events
        protected DataStructure selectedDataStructure = null;
        public Form1()
        {
            InitializeComponent();
            // create your default values here
            dataItems.Add(new DataStructure { A = 0.5, B = 100, Title = "Some value" });
            dataItems.Add(new DataStructure { A = 0.75, B = 100, Title = "More value" });
            dataItems.Add(new DataStructure { A = 0.95, B = 100, Title = "Even more value" });
            // assign the dataitems to the combobox datasource
            comboBox1.DataSource = dataItems;
            // Say what the combobox should show in the dropdown
            comboBox1.DisplayMember = "Title";
            // set it to list only, no typing
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // register to the event that triggers each time the selection changes
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        // a method to add items to the dataItems (and automatically to the ComboBox thanks to the BindingContext)
        private void Add(double a, int b, string title)
        {
            dataItems.Add(new DataStructure { A = a, B = b, Title = title });
        }
        // when the value changes, update the selectedDataStructure field
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo == null)
            {
                return;
            }
            selectedDataStructure = combo.SelectedItem as DataStructure;
            if (selectedDataStructure == null)
            {
                MessageBox.Show("You didn't select anything at the moment");
            }
            else
            {
                MessageBox.Show(string.Format("You currently selected {0} with A = {1:n2}, B = {2}", selectedDataStructure.Title, selectedDataStructure.A, selectedDataStructure.B));
            }
        }
        // to add items on button click
        private void AddComboBoxItemButton_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("A title is required!");
                return;
            }
            Random random = new Random();
            double a = random.NextDouble();
            int b = random.Next();
            Add(a, b, title);
            textBox1.Text = string.Empty;
        }
    }
