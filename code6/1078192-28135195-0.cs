    public class YourViewModel : INotifyPropertyChanged
    {
       // ... your code here
       public StateObjectType State
       {
           get {return person.state;}
       }
       // when you modify the person state just call OnPropertyChanged("State")
    }
