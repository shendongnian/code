     private MyViewModelType viewmodel;
        public MyViewModelType ViewModel
        {
            get 
            { 
                if(viewmodel == null)
                {
                    viewmodel = new MyViewModelType();
                }
                return viewmodel; 
            }
            set 
            { 
                viewmodel = value; 
                OnPropertyChanged("ViewModel")
            }
        }
