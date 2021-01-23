ObservableCollection
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
    <Window.DataContext>
        <local:ViewModel />
    </Window.DataContext>
    
    <Grid>
        <ListBox ItemsSource="{Binding Path=MyCollection}" /> <!-- or any other control -->
    </Grid>
Work with collection
    ViewModel MyViewModel = this.DataContext as ViewModel;
    MyViewModel.MyCollection = new ObservableCollection<Person>();
    MyViewModel.MyCollection.Add(new Person()
    {
        Age = 22,
        Name = "Nick",
    });
