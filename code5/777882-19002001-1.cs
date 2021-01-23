    namespace MVVMTests
    {
        public class MainWindowViewModel : NotificationObject
        {
            private Boolean isSelected;
            public MainWindowViewModel()
            {
                isSelected = true;
            }
            public Boolean IsSelected
            {
                get { return this.isSelected; }
                set
                {
                    this.isSelected = value;
                    this.RaisePropertyChanged<Boolean>(() => IsSelected);
                }
            }
        }
    }
