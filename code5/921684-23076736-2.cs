ObservableCollection<T>
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<Person> _myCollection;
        public ObservableCollection<Person> MyCollection
        {
           get
           {
               return _myCollection;
           }
           set
           {
               _myCollection = value;
               NotifyPropertyChanged("MyCollection");
           }
        }
    }
XAML
    <!-- Set the DataContext in XAML -->
    <Window.DataContext>
        <local:ViewModel />
    </Window.DataContext>
    
    <Grid>
        <ListBox ItemsSource="{Binding Path=MyCollection}" /> <!-- Or any other control -->
    </Grid>
