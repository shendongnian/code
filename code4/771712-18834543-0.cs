    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Car SelectedCar { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public class Car
        {
            public string Name { get; set; }
            public string Make { get; set; }
            public string Year { get; set; }
        }
        private void generate_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = new List<Car>();
            int i = 0;
            string[] name = { "Sentra", "IS", "Camry" };
            string[] make = { "Nissan", "Lexus", "Toyota" };
            string[] year = { "2000", "2011", "2013" };
            foreach (string s in name)
            {
                cars.Add(new Car() { Name = name[i], Make = make[i], Year = year[i] });
                i++;
            }
            carList.ItemsSource = cars;
        }
        private void GetValue_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text = string.Format("{0} {1} {2}", SelectedCar.Year, SelectedCar.Make, SelectedCar.Name);
        }
    }
