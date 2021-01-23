        public class Company
        {
            public List<Vehicle> Vehicles;
            public Company()
            {
                Vehicles = new List<Vehicle>() { new Vehicle(1), new Vehicle(2), new Vehicle(3) };
            }
        }
        public class Vehicle
        {
            private string _vehicleNum;
            public Vehicle(int num)
            {
                _vehicleNum = "Vehicle" + num.ToString();
            }
            public string getDetails()
            {
                return _vehicleNum;
            }
        }
        Company ACompany = new Company();
        public MainWindow()
        {
            InitializeComponent();
            foreach(Vehicle v in ACompany.Vehicles)
                listbox1.Items.Add(v.getDetails());
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listbox1.SelectedItems.Count; i++)
            {
                foreach(Vehicle v in ACompany.Vehicles)
                {
                    if (String.Equals(v.getDetails(), listbox1.SelectedItems[i].ToString()))
                    {
                        ACompany.Vehicles.Remove(v);
                        break;
                    }
                }
                listbox1.Items.Remove(listbox1.SelectedItems[i]);
            }
        }
