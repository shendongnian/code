    public class MonthYearModel
    {
        public string month;
        public string year;
        public MonthYearModel(string dateTime)
        {
            var date = Convert.ToDateTime(dateTime);
            this.month = date.ToString("MMMM");
            this.year = date.ToString("yyyy");
        }
        
        public bool Equals(object arg)
        {
            var model = arg as MonthYearModel;
            return (model != null) && model.month == this.month && model.year == this.year;
        }
        public int GetHashCode()
        {
            return (month.GetHashCode() * 397) ^ year.GetHashCode();
        }
    }
    List<MonthYearModel> = eventListResponse.result.Select(s => new MonthYearModel(s.startDate)).Distinct().ToList();
