    public class ViewModel : INotifyPropertyChanged {
    
       public void ViewModel() {
        SwitchCommand = new DelegateCommand(() => this.IsEnabled = true, () => true);
       }
    
       public DelegateCommand SwitchCommand {get;set;}
    
       private bool isEnabled;
       public bool IsEnabled {
        get {
          return isEnabled;
        }
        set {
          isEnabled = value;
          NotifyPropertyChanged("IsEnabled");
        }
    
    // here, InotifyPropertyChanged implementation, dozens of sample available
    }
