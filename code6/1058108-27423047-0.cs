     public ObservableCollection<Credits> CreditInfo
        {
            get
            {
                return infos;
            }
            set
            {
                infos = value;
                OnPropertyChanged("CreditInfo");
                OnPropertyChanged("CreditPercentage");
                //OnPropertyChanged("PercentageDescription");
            }
        }public string PercentageDescription
        {
            get
            {
                return percentageDescription;
            }
            set
            {
                percentageDescription = value;
                OnPropertyChanged("PercentageDescription");
            }
        }
   
    
