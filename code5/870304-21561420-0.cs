      public class IssuesItems : INotifyPropertyChanged
      {
          private string issue;
          public string Issue
          {
              get { return issue; }
              set
              {
                  if(issue != value)
                  {
                     issue= value;
                     // Call OnPropertyChanged whenever the property is updated
                     OnPropertyChanged("Issue");
                  }
              }
          }
    
          // Declare the event 
          public event PropertyChangedEventHandler PropertyChanged;
          // Create the OnPropertyChanged method to raise the event 
          protected void OnPropertyChanged(string name)
          {
              PropertyChangedEventHandler handler = PropertyChanged;
              if (handler != null)
              {
                  handler(this, new PropertyChangedEventArgs(name));
              }
          }
      }
