        public class MyViewModel : INotifyPropertyChanged
        {
            public MyViewModel()
            {
               _myCommand = new MyCommand(FuncToCall,FuncToEvaluate);
            }
            private ICommand _myCommand;
  
            public ICommand MyButtonClickCommand
            {
                get { return _myCommand; }
                set { _myCommand = value; }
            }
    
            private void FuncToCall(object context)
            {
                //this is called when the button is clicked
                //for example
                if (this.ChangeControlVisibility== Visibility.Collapsed)
                {
                  this.ChangeControlVisibility = Visibility.Visible;   
                }
                else
                {
                  this.ChangeControlVisibility = Visibility.Collapsed;  
                }                
            }
    
            private bool FuncToEvaluate(object context)
            {            
                return true;
            }
            private Visibility _visibility = Visibility.Visible;
            public Visibility ChangeControlVisibility
            {
                get { return _visibility; }
                set {
                     _visibility = value;
                     this.OnPropertyChanged("ChangeControlVisibility");
                }    
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
