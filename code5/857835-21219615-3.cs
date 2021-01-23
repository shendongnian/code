    public class MainViewModel : BaseViewModel
    {
    
    }
    
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public object Model { get; set; }
    
        #region PropertyChanged
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        #endregion
    
        #region Commands
    
        public ICommand OpenFooWindowClicked
        {
            get
            {
                //implement your ICommand here... beyond the scope of the question.
            }
        }
    
        #endregion
    }
