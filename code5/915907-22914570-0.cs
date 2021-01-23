    public class ButtonViewModel : INotifyPropertyChanged
    {
       private string _content;
       public string Content
       {
          get{ return _content; }
          set{ _content = value; OnPropertyChanged("Content"); }
       }
    
       // you'll need to implement INotifyPropertyChanged
       // also take a look at RelayCommand
    
       // here is your command for you're button
       public ICommand ButtonCommand
       {
          get { return new RelayCommand(execute, canExecute); }
       }
    
       private void execute()
       {
         // my actual command code
       }
    
       private bool canExecute()
       {
          // this will automatically toggle the enabled state on my button
       }
    }
