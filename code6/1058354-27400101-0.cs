    public GenericViewModel Generic
        {
            get 
            { 
                if(_generic == null)
                {
                    GenericFactory.Create();
                }
                return _generic;
            }
            private set
            {
                if (_generic != value)
                {
                    _generic = value;
                    base.OnPropertyChanged("Generic");
                }
            }
        }
