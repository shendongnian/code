    public class ViewModel:INotifyPropertyChanged {
    
        private String _url;
        private String _TemplateType;
                
        public ViewModel(){
            UpdateCommand = new DelegateCommand(OnExecuteUpdate, OnCanExecuteUpdate);
        }
            
        public bool OnCanExecuteUpdate(object param){
            // insert logic here to return true when one can update
            // or false when data is incomplete
        }
            
        public void OnExecuteUpdate(object param){
            // insert logic here to update your model using data from the view model
        }
        
        public ICommand UpdateCommand { get; set;}
        
        public string URL{
            get { return _url;  }
            set {
                if (value != _url) {
                    _url= value;
                    OnPropertyChanged("URL");
                }
            }
        }
                
        public string TemplateType {
            get { return _TemplateType;  }
            set {
                if (value != _TemplateType) {
                    _TemplateType= value;
                    OnPropertyChanged("TemplateType");
                }
            }
        }
        
        ... etc.
    }
        
    public class DelegateCommand : ICommand {
        Func<object, bool> canExecute;
        Action<object> executeAction;
         
        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, null) {}
         
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute) {
            if (executeAction == null) {
                throw new ArgumentNullException("executeAction");
            }
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }
         
        public bool CanExecute(object parameter) {
            bool result = true;
            Func<object, bool> canExecuteHandler = this.canExecute;
            if (canExecuteHandler != null) {
                result = canExecuteHandler(parameter);
            }
         
            return result;
        }
         
        public event EventHandler CanExecuteChanged;
         
        public void RaiseCanExecuteChanged() {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null) {
                handler(this, new EventArgs());
            }
        }
         
        public void Execute(object parameter) {
            this.executeAction(parameter);
        }
    }
