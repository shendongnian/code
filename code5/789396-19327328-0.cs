    class YearModel : INotifyPropertyChanged
    {
    #region Members
        MyERM.tblYear _year;
    #endregion
    #region Properties
        public MyERM.tblYear Year
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
        public String Description
        {
            get { return Year.Description; }
            set
            {
                Year.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
    #endregion
    #region Construction
        public YearModel()
        {
            this._year = new MyERM.Year
            {
                id = 0,
                Description = ""
            };
        }
    #endregion
    }
