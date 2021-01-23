       public class PopulateData
       {
            public int       InputID;
            public String    TraderID;
            public DateTime  TradeDate;
            public TimeSpan  TradeTime;
            public string    ClientName;
            public string    CurPair;
            public int       Amnt;
            public string    Action;
            public decimal   ExecutedRate;
            public PopulateData(int iId, string tId, DateTime date, TimeSpan tTime, string cName, string curPair, int amnt, string Act, decimal ExRate)
            {
              InputID   = iId; 
              TraderID  = tId;
              TradeDate = date;
              TradeTime  = tTime;
              ClientName = cName;
              CurPair    = curPair;
              Amnt       = amnt;
              Action     = Act;
              ExecutedRate = ExRate;
            }
       }
 
