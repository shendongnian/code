    class YearFormViewModel
    {
        public YearListModel YearList { get; set; }
        public YearGroupListModel YearGroupList { get; set; }
        public YearFormViewModel()
        {
            YearList = new YearListModel;
            YearGroupList = new YearGroupListModel();
        }
    }
