    class YearModel : INotifyPropertyChanged
    {
        #region Members
        myService.Year _year;
        #endregion
        #region Properties
        public myService.Year Year
        {
            get { return _year; }
        }
        public Int32 id
        {
            get { return Year.id; }
            set
            {
                Year.id = value;
                NotifyPropertyChanged("id");
            }
        }
        public String Code
        {
            get { return Year.Code; }
            set
            {
                Year.Code = value;
                NotifyPropertyChanged("Code");
            }
        }
    #region Construction
        public YearModel()
        {
            this._year = new SchoolMonitor_Service.Year
            {
                id = 0,
                Code = "",
            };
        }
        #endregion
    }
