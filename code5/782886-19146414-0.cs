    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable teams = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            
            loadDataGrid();
            this.DataContext = this;
        }
        private void loadDataGrid()
        {
            teams.Columns.Add("Location");
            teams.Columns.Add("Name");
            teams.Columns.Add("Conference");
            teams.Columns.Add("Division");
            teams.Rows.Add("Baltimore", "Ravens", "AFC", "North");
            teams.Rows.Add("Cincinnati", "Bengals", "AFC", "North");
            teams.Rows.Add("Cleveland", "Browns", "AFC", "North");
            teams.Rows.Add("Pittsburgh", "Steelers", "AFC", "North");
            teams.Rows.Add("Houston", "Texans", "AFC", "South");
            teams.Rows.Add("Indianapolis", "Colts", "AFC", "South");
            teams.Rows.Add("Jacksonville", "Jaguars", "AFC", "South");
            teams.Rows.Add("Tennessee", "Titans", "AFC", "South");
            teams.Rows.Add("Buffalo", "Bills", "AFC", "East");
            teams.Rows.Add("Miami", "Dolphins", "AFC", "East");
            teams.Rows.Add("New England", "Patriots", "AFC", "East");
            teams.Rows.Add("New York", "Jets", "AFC", "East");
            teams.Rows.Add("Denver", "Broncos", "AFC", "West");
            teams.Rows.Add("Kansas City", "Chiefs", "AFC", "West");
            teams.Rows.Add("Oakland", "Raiders", "AFC", "West");
            teams.Rows.Add("San Diego", "Chargers", "AFC", "West");
            teams.Rows.Add("Chicago", "Bears", "NFC", "North");
            teams.Rows.Add("Detroit", "Lions", "NFC", "North");
            teams.Rows.Add("Green Bay", "Packers", "NFC", "North");
            teams.Rows.Add("Minnesota", "Vikings", "NFC", "North");
            teams.Rows.Add("Atlanta", "Falcons", "NFC", "South");
            teams.Rows.Add("Carolina", "Panthers", "NFC", "South");
            teams.Rows.Add("New Orleans", "Saints", "NFC", "South");
            teams.Rows.Add("Tampa Bay", "Buccaneers", "NFC", "South");
            teams.Rows.Add("Dallas", "Cowboys", "NFC", "East");
            teams.Rows.Add("New York", "Giants", "NFC", "East");
            teams.Rows.Add("Philadelphia", "Eagles", "NFC", "East");
            teams.Rows.Add("Washington", "Redskins", "NFC", "East");
            teams.Rows.Add("Arizona", "Cardinals", "NFC", "West");
            teams.Rows.Add("San Francisco", "49ers", "NFC", "West");
            teams.Rows.Add("Seattle", "Seahawks", "NFC", "West");
            teams.Rows.Add("St. Louis", "Rams", "NFC", "West");
            dataGrid1.DataContext = teams;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }
    }
    [ValueConversion(typeof(string), typeof(Brush))]
     public class  ConverterColor:IValueConverter
     {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             SolidColorBrush solColBrsh=new SolidColorBrush(Colors.Red); 
             string conference = (value as string);
             switch (conference)
             {
                 case "AFC":
                     solColBrsh = new SolidColorBrush(Colors.Pink);
                     break;  
                 case "NFC":
                     solColBrsh = new SolidColorBrush(Colors.BlueViolet);
                     break;  
                 default:
                     break;
             }
             return solColBrsh; 
         }
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             throw new NotImplementedException();
         }
     }
