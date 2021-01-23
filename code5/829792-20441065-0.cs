    public partial class Form2 : Form
    {
        private List<string> allPeople = new List<string>();
        public void SetAllPeople(List<string> input)
        {
            allPeople.AddRange(input);
        }
    
        public Form2()
        {
            InitializeComponent();
    
            foreach (string s in allPeople)
            {
                lsbResidents.Items.Add(s);
            }
        }
    }
