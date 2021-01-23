    public class YourClass: INotifyPropertyChanged
      {
          private ObservableCollection<Model.ChildCommand> _childCommands;
    
          public event PropertyChangedEventHandler PropertyChanged;
    
          public ObservableCollection<Model.ChildCommand> ChildCommands
          {
              get { return _childCommands; }
              set
              {
                  _childCommands= value;
                  OnPropertyChanged("ChildCommands");
              }
          }
    
          protected void OnPropertyChanged(string name)
          {
              PropertyChangedEventHandler handler = PropertyChanged;
              if (handler != null)
              {
                  handler(this, new PropertyChangedEventArgs(name));
              }
          }
      }
