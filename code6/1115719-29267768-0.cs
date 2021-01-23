    public class ItemViewModel : ViewModelBase
    {
        #region Name
        public const string NamePropertyName = "Name";
        private string _name = null;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                RaisePropertyChanging(NamePropertyName);
                _name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }
        #endregion
        #region IsChecked
        public const string IsCheckedPropertyName = "IsChecked";
        private bool _myIsChecked = false;
        public bool IsChecked
        {
            get
            {
                return _myIsChecked;
            }
            set
            {
                if (_myIsChecked == value)
                {
                    return;
                }
                RaisePropertyChanging(IsCheckedPropertyName);
                _myIsChecked = value;
                RaisePropertyChanged(IsCheckedPropertyName);
            }
        }
        #endregion
        
    }
