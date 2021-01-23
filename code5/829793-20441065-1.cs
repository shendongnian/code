    public partial class Form2 : Form
    {
        public void SetAllPeople(List<string> input)
        {
            foreach (string s in input)
            {
                lsbResidents.Items.Add(s);
            }
        }
    
        public Form2()
        {
            InitializeComponent();
        }
    }
