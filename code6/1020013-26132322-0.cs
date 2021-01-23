    public class AcctList
    {
        public string sRole { get; set; }
        public bool bIsPrimary { get; set; }
        public int iDayNo { get; set; }
        public bool bIsAirportMeetGreet { get; set; }
        public bool bIsSeaportMeetGreet { get; set; }
        public override string ToString()
        {
            return base.ToString();
            //return your desired string here
        }
    }
