    namespace WPFPlayground.ViewModel
    {
        public class ProductViewModel : ViewModelBase
        {
            private string _name;
            private bool _isDefective;
    
            public bool IsDefective
            {
                get { return _isDefective; }
                set { SetValue(ref _isDefective, value); }
            }
    
            public string Name
            {
                get { return _name; }
                set { SetValue(ref _name, value); }
            }
        }
    }
