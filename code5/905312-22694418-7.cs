        public class ApplicationViewModel : ViewModelBase
        {
    ...
            #region ToolbarEnabled
            public bool ToolbarEnabled
            {
                get { return _toolbarEnabled; }
                set
                {
                    if (_toolbarEnabled != value)
                    {
                        _toolbarEnabled = value;
                        RaisePropertyChanged("ToolbarEnabled");
                    }
                }
            }
            #endregion
