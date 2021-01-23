    static void Main(string[] args)
            {
                Console.WriteLine(DateTime.Now);
                Console.ReadLine();
            }
    
            public static long ToUnixTimestamp( DateTime target)
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
                var unixTimestamp = System.Convert.ToInt64((target - date).TotalSeconds);
    
                return unixTimestamp;
            }
    
            public static DateTime ToDateTime( DateTime target, long timestamp)
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
    
                return dateTime.AddSeconds(timestamp);
            }
