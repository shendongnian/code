    public class Standard : INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        // Create the OnPropertyChanged method to raise the event 
          protected void NotifyOfPropertyChanged(string name)
          {
              PropertyChangedEventHandler handler = PropertyChanged;
              if (handler != null)
              {
                  handler(this, new PropertyChangedEventArgs(name));
              }
          }
    
          protected void NotifyOfPropertyChanged(Expression<Func<TProperty>> property)
          {
              NotifyOfPropertyChanged(property.GetMemberInfo().Name);
          }
    
        string _title;
        ObservableCollection<string> _questions;        
    
        public string Title
        {
            get { return _title; }
            set { 
                _title = value;
                NotifyOfPropertyChanged(()=>Title);
            }
        }
    
        public ObservableCollection<string> Questions
        {
            get { return _questions; }
            set { 
                _questions = value;
                NotifyOfPropertyChanged(()=>Questions);
            }
        }
    }
