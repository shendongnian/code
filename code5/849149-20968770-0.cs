    public class Standard : INotifyPropertyChanged
    {
        string _title;
        ObservableCollection<string> _questions;
        public event PropertyChangedEventHandler PropertyChanged;
    
      #region NofiftyPropChnage
      protected void NotifyOfPropertyChanged(string name)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
      }
    
      protected void NotifyOfPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
      {
          NotifyOfPropertyChanged(property.GetMemberInfo().Name);
      }
      #endregion
    
      #region Properties
      public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChanged(() => Title);
            }
        }
    
        public ObservableCollection<string> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                NotifyOfPropertyChanged(() => Questions);
            }
        }
      #endregion
    }
