    class YearListModel
    {
        myService.myServcieClient service = new myService.myServcieClient();
        #region Members
        private ObservableCollection<YearModel> _years;
        #endregion
        #region Properties
        public ObservableCollection<YearModel> Years
        {
            get { return _years; }
        }
        #endregion
        #region Construction
        public YearListModel()
        {
            _years = new ObservableCollection<YearModel>();
            foreach (SchoolMonitor_Service.Year y in service.GetYearList())
            {
                _years.Add(new YearModel
                {
                    id = y.id,
                    Code = y.Code
                }
                                );
            }
        }
        #endregion
    }
