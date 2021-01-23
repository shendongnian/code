    public class MainWindows_ViewModel:INotifyPropertyChanged
    {
        public MainWindows_ViewModel()
        {
            //Here i set the default ViewModel
            this.Child=new First_ViewModel(){Parent=this};
        }
    
        private IChildLayout _child;
        public IChildLayout Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child=value;
                _child.Parent=this;
                NotifyPropertyChanged("Child");
            }
        }
        #region INotifyPropertyChangedMembers...
    }
