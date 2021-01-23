    public class MyViewModel() : INotifyPropertyChanged
    {
    
    ICommand _OKCommand;
    public ICommand OKCommad
    {
      get { return _OKCommand; }
      set { _OKCommand = value; PropertyChanged(OKCommad); }
    }
    
    public MyViewModel()
    {
      this.OKCommand += new DelegateCommand(OKCommand_Execute);
    }
    
    public void OKCommand_Execute()
    {
     // Code for button click here
    }
    
    }
