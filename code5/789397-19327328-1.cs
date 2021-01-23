    class YearListModel
    {
        myERM db = new myERM();
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
            foreach (MyERM.tblYear y in db.tblYears())
            {
                _years.Add(new YearModel
                {
                    id = y.id,
                    Description = y.Description
                }
              );
            }
        }
        #endregion
    }
