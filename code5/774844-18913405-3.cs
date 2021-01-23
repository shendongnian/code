    public class HobbiesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Hobby> _hobbies;
        public ObservableCollection<Hobby> HobbiesCollection
        {
             get 
             {
                 return _hobbies;
             }
             set
             {
                 _hobbies = value;
                 OnPropertyChanged();
             }
        }
        //Constructor
        public HobbiesViewModel
        {
            HobbiesCollection = new ObservableCollection<Hobby>();
        }
        //INotifyPropertyChanged interface member implementation ...
    }
Third, create an instance of the ViewModel (the ObservableCollection). Use this quick help out : In the App.xaml.cs, create a static object and use it through the app as you need it :
    public partial class App
    {
    
    //This already exists in your app's code, but I've written it to
    //make an idea where to write the Hobbies object
    public static PhoneApplicationFrame RootFrame { get; private set; }
    public static HobbiesViewModel Hobbies;
    //Again, the already existing constructor
    public App()
    {
       ...
       Hobbies = new HobbiesViewModel();
    }
Now, you almost have it all set; You have the Model, you have the ViewModel, all that's left is to create the connection with the View. This can be easily done through binding. The ViewModel represents the DataContext of your control (in your case the LongListSelector, so in that View's (Page's) constructor, write the following statement :
    yourListControlName.DataContext = App.Hobbies;
