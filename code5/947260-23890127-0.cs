        #region SomeProperty
        private IBidirectionalSomeProperty<DesiredState, EdgeViewModel> _SomeProperty;
        private const string SomePropertyName = "SomeProperty";
        public IBidirectionalSomeProperty<DesiredState, EdgeViewModel> SomeProperty
        {
            get { return _SomeProperty; }
            set
            {
                if (_SomeProperty != value)
                {
                    _SomeProperty = value;
                    RaisePropertyChanged(SomePropertyName);
                }
            }
        }
        #endregion
