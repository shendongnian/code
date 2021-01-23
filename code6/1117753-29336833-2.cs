            private ICommand _checkBoxCommand;
            public ICommand CheckBoxCommand
            {
                get
                {
                    return _checkBoxCommand = _checkBoxCommand ?? new RelayCommand((param) => {
                        var model = param as Model;
    
                        //Do whatever with the model
    
                    });
                }
            }
