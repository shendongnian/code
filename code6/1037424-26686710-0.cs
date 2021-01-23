    public class YourViewModel
    {
        public List<YourModel> Models { get; set; }
    }
    public class YourModel : INotifyPropertyChanged
    {
         private string yourText;
         public string YourText 
         { 
             get { return yourText; }
             set
             {
                 yourText = value;
                 NotifyPropertyChanged("YourText");
             }
          }
          // add INotifyPropertyChanged implementation here
    }
