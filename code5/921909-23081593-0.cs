XAML
    <Grid>
        <ListBox Name="MyListBox"
                 ItemsSource="{Binding Path=MyCollection}" />
    </Grid>
Code-behind
    public partial class MainWindow : Window
    {
        ViewModel MyViewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MyViewModel;
            MyViewModel.MyCollection = new ObservableCollection<Person>();
            MyViewModel.MyCollection.Add(new Person()
            {
                Age = 22,
                Name = "Nick",
            });
            MyViewModel.MyCollection.Add(new Person()
            {
                Age = 11,
                Name = "Sam",
            });
            MyViewModel.MyCollection.Add(new Person()
            {
                Name = "Kate",
                Age = 15,
            });
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding("Age"));
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);
            var template = new DataTemplate();            
            template.VisualTree = textBlockFactory;
            MyListBox.ItemTemplate = template;
        }
    }
    public class ViewModel : NotificationObject
    {
        #region MyCollection
        public ObservableCollection<Person> MyCollection
        {
            get;
            set;
        }
        #endregion
    }
    #region Model
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
    }
    #endregion
    #region NotificationObject
    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    #endregion
