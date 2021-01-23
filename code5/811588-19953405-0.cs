            get
            {
                return _theMapViewModel;
            }
            set
            {
                _theMapViewModel = value;
                DataContext = _theMapViewModel.TheModel;
            }
        }
