    public Class EmploymentHistory{
        public EmploymentHistory(){
            StateList = new List<SelectListItem>();
            MonthList = new List<SelectListItem>();
            YearList = new List<SelectListItem>();
        }
        public string RecordNum { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public string SelectedState { get; set; }
        public List<SelectListItem> MonthList { get; set; }
        public string SelectedMonth { get; set; }
        public List<SelectListItem> YearList { get; set; }
        public string SelectedYear { get; set; }
    }
