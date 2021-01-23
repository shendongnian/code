        private CultureInfo _culture;
        public CultureInfo Culture
        {
            get { return _culture; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");
                if (_culture != value)
                {
                    RaisePropertyChanging(() => Culture);
                    _culture = value;
                    RaisePropertyChanged(() => Culture);
                    if (CultureManager.UICulture.Name != _culture.Name)
                    {
                    CultureManager.UICulture = _culture;  // line A
                    }
                 }
            }
        }
