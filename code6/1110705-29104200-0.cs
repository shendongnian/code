    public struct Data
        {
            public Data(string keyValue, string strValue)
            {
                key = keyValue;
                date =  Convert.ToDateTime(strValue);
            }
    
            public string key { get; private set; }
            public DateTime date { get; private set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var test = new List<Data>();
                test.Add(new Data("1", "93/01/01"));
                test.Add(new Data("2", "93/01/02"));
                test.Add(new Data("3", "93/01/03"));
                test.Add(new Data("4", "93/01/04"));
                test.Add(new Data("5", "93/01/05"));
                test.Add(new Data("6", "93/01/06"));
                test.Add(new Data("7", "93/01/07"));
    
                var asdf = test.Where(x => x.date >= Convert.ToDateTime("1993/01/01") && x.date <= Convert.ToDateTime("1993/01/10"));
            var asdff= from t in test
                       where t.date >= Convert.ToDateTime("1993/01/01") && t.date <= Convert.ToDateTime("1993/01/10")
                       select t;
    
            }
        }
