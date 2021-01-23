XAML
    <Window x:Class="TestUpdatePropertyChanged.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:this="clr-namespace:TestUpdatePropertyChanged"
            Title="MainWindow" Height="350" Width="525">
    
        <Window.DataContext>
            <this:TestViewModel />
        </Window.DataContext>
    
        <Grid>
            <TextBox Width="100" Height="25" Text="{Binding Path=TestString, UpdateSourceTrigger=PropertyChanged}" />
        
            <Button Width="100" Height="30" VerticalAlignment="Top" Content="Click" Click="Button_Click" />
        </Grid>
    </Window>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testData = this.DataContext as TestViewModel;
            testData.TestString = "Yay, it's change!";
            if (testData.HasChanges == true) 
            {
                MessageBox.Show("It's Change!");
            }
        }
    }
    public class TestViewModel : ModelBase 
    {
       private string _testString = "test";
        public string TestString
        {
            get { return _testString; }
            set
            {
                if (_testString != value)
                {
                    _testString = value;
                    RaisePropertyChanged("TestString");
                }
            }
        }
    } 
    public abstract class ModelBase : INotifyPropertyChanged
    {
        protected ModelBase()
        {
        }
        private bool _hasChanges;
        public bool HasChanges
        {
            get
            { 
                return _hasChanges;
            }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    RaisePropertyChanged("HasChanges");
                }
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            HasChanges = true;
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
