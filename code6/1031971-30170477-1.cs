    class MyViewModel{
       private ObservableCollection<OUTAGE_DETAILS> _allOutageDetails;
            /// <summary>
            /// ObservableCollection de tous les outage details
            /// </summary>
            public ObservableCollection<OUTAGE_DETAILS> AllOutageDetails
            {
                get
                {
                    return _allOutageDetails;
                }
                set
                {
                    _allOutageDetails= value;
                }
            }
            public MyViewModel()
            {
                _allOutageDetails = LoadOutageDetails();
            }
    }
