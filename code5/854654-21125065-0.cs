    <Window x:Class="WpfApplication8.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <ComboBox  SelectedItem="{Binding SelectedStatus}">
                <ComboBoxItem Content="Normal" />
                <ComboBoxItem Content="Expedited" />
            </ComboBox>
        </Grid>
    </Window>
    namespace WpfApplication8
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            employmentApplication  emp = new employmentApplication();  
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = emp;  
            }
        }
        public class employmentApplication:INotifyPropertyChanged
        {
            private byte appType = 0; // 1 = normal; 2 = expedited
    
            public byte AppType
            {
                get { return appType; }
                set
                {
                    appType = value;
                    this.OnPropertyChanged("AppType");
                }
            }
    
            public string SelectedStatus
            {
                get { return _selectedStatus; }
                set
                {
                    _selectedStatus = value;
                    if (_selectedStatus == "Normal")
                    {
                        AppType = 0;
                    }
                    else
                        AppType = 1;
                    this.OnPropertyChanged("SelectedStatus");
                }
            }      
    
            public event PropertyChangedEventHandler PropertyChanged;
            private string _selectedStatus;
    
            void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
            }
        }
    }
