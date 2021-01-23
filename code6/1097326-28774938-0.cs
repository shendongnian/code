      static void Main(string[] args)
        {
             //Example to test, I'm working with a Database
            List<Tuple<DateTime, string>> repo = new List<Tuple<DateTime, string>>(){new Tuple<DateTime, string>(new DateTime(2015,1,1,1,0,0),"Some Data" ),
                                                                                      new Tuple<DateTime, string>(new DateTime(2015,1,1,1,25,0),"Some Data" ),
                                                                                      new Tuple<DateTime, string>(new DateTime(2015,1,1,1,40,0),"Some Data" ),
                                                                                      new Tuple<DateTime, string>(new DateTime(2015,1,1,2,0,0),"Some Data" )};
           
    
            var query = from  dateTime in  GenerateStaticListOfDateTime(1,2015)
                        join item in repo on dateTime equals item.Item1 into data
                        from item2 in data.DefaultIfEmpty(new Tuple<DateTime, string>(dateTime,"Null data"))
                        select item2;
            foreach (var item in query)
            {
                 Console.WriteLine("DateTime:{0} Data:{1}  ",item.Item1,item.Item2);
            }
        }
    
        public static List<DateTime> GenerateStaticListOfDateTime(int month,int year)
        {
            var result = new List<DateTime>();
            for (int i = 1; i <= DateTime.DaysInMonth(year,month); i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    result.Add(new DateTime(year,month,i,j,0,0));
                }
            }
            return result;
        }
