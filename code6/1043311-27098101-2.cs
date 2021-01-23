    public class ReportParamViewModel 
    {
        public string ProjectName {get;set;}
        public int FromMonth {get;set;}
        public int FromYear {get;set;}
        public int ToMonth {get;set;}
        public int ToYear {get;set;}
        public DateTime GetFromDate()
        {
            return new DateTime(FromYear, FromMonth, 1);
        }
        public DateTime GetToDate()
        {
            return new DateTime(ToYear, ToMonth, 1);
        }
    }
