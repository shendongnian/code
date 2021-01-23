        public class Company
        {
            public List<string> Vehicles;
            public Company()
            {
                Vehicles = new List<string>() { "Mars Rover", "Golf Cart", "Go Kart", "Ferrari" };
            }
        }
        Company ACompany = new Company();
        public MainWindow()
        {
            InitializeComponent();
            foreach(string s in ACompany.Vehicles)
                listbox1.Items.Add(s);
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listbox1.SelectedItems.Count; i++)
            {
                ACompany.Vehicles.Remove(listbox1.SelectedItems[i].ToString());
                listbox1.Items.Remove(listbox1.SelectedItems[i]);
            }
        }
