        class ViewModel:INotifyPropertyChanged
        {    
            private String _url;
            private String _TemplateType;
            public ICommand UpdateCommand { get; set;}
        
            public ViewModel(){
                UpdateCommand = new DelegateCommand(OnExecuteUpdate, OnCanExecuteUpdate);
            }
    
            public bool OnCanExecuteUpdate(object param){
                // insert logic here to return true when one can update
                // or false when data is incomplete
            }
    
            public void OnExecuteUpdate(object param){
                // insert logic here to update your model using data from the view model
            }
    
            public string URL
            {
                get { return _url;  }
                set
                {
                    if (value != _url)
                    {
                        _url= value;
                        OnPropertyChanged("URL");
                    }
                }
            }
        
            public string TemplateType
            {
                get { return _TemplateType;  }
                set
                {
                    if (value != _TemplateType)
                    {
                        _TemplateType= value;
                        OnPropertyChanged("TemplateType");
                    }
                }
            }
            ... etc.
        }
