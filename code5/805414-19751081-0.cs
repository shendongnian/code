    class ViewModel
        {
            private ObservableCollection<string> _strings = new ObservableCollection<string>();
    
            public ObservableCollection<string> Strings //It's our binding property
            {
                get
                {
                    return _strings;
                }
                set
                {
                    if (value==null)
                    {
                        throw new NullReferenceException();
                    }
                    _strings = value;
                }
            }
        } 
