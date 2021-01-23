    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        bool _isCurrentPage;
        
        protected MyData MyData { get; private set; }
        public ViewModelBase(MyData myData)
        {
            MyData = myData;
        }
    }
    public class WelcomePageViewModel : ViewModelBase
    {  
        public WelcomePageViewModel(MyData myData)
            : base(myData)
        {
           // Access the protected property
           MyLogger.WriteLine("Grabbed an instance of myData: " + MyData.ToString());
        }
    }
