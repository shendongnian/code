    ...
        private ObservableCollection<TripsResponseType> _tripsViewModelDataSource;
        public ObservableCollection<TripsResponseType> TripsViewModelDataSource
        {
            get
            {
                if (null == this._tripsViewModelDataSource)
                {
                    this._tripsViewModelDataSource = new ObservableCollection<TripsResponseType>();
                }
                return this._tripsViewModelDataSource;
            }
        }
    ...
