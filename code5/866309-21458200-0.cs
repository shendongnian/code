    class MonthCurrency
        {
            public string Month { get; set; }
            public int CurrencyCode { get; set; }
            public decimal Amount { get; set; }
        }
        static List<MonthCurrency> inputTable  = null;
        static void Main(string[] args){
            inputTable = new List<MonthCurrency>()
            {     new MonthCurrency() { Month = "October", CurrencyCode= 1, Amount = 1},
                  new MonthCurrency() { Month = "October", CurrencyCode= 1, Amount = 2},
                  new MonthCurrency() { Month = "November", CurrencyCode= 2, Amount = 1},
                  new MonthCurrency() { Month = "November", CurrencyCode= 2, Amount = 2},
                  new MonthCurrency() { Month = "December", CurrencyCode= 3, Amount = 1},
                  new MonthCurrency() { Month = "December", CurrencyCode= 3, Amount = 2},
            };   
            var result = GetCurrencyCode("November");
        }
        static public decimal GetCurrencyCode(string inputParameter)
        {
            decimal retVal = 0.0M;
            var results = from p in inputTable.AsEnumerable()
                          where p.Month == inputParameter
                          group p by new
                          {
                              p.CurrencyCode,
                          } into groupedTable
                          select new MonthCurrency
                          {                              
                              Amount = groupedTable.Sum(r => r.Amount)
                          };
            if (results.Count() > 0)
            {
                retVal = results.ElementAt(0).Amount;
            }
            return retVal;
        }
