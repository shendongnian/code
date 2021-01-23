    public class test
    {
        public int IdAirport;
        public int IdUser;
        public DateTime AddedDate;
    
        public test(int IdAirport, int IdUser, DateTime AddedDate)
        {
            this.IdAirport = IdAirport;
            this.IdUser = IdUser;
            this.AddedDate = AddedDate;
        }
    }
    
        void Main()
        {
            List<test> tests = new List<test>()
    	{
    	new test(2,   5126,    DateTime.Parse("2014-10-23 14:54:32.677")),
    	new test(2,   5127,    DateTime.Parse("2014-10-23 14:55:32.677")),
    	new test(1 ,  5128 ,   DateTime.Parse("2014-10-23 14:56:32.677")),
    	new test(2  , 5129  ,  DateTime.Parse("2014-10-23 14:57:32.677"))
    	};
            
            var r = tests
    		.Where(t => t.IdAirport == 2)
    		.OrderBy(t => t.AddedDate)
    		.TakeWhile(t => t.IdUser != 5129)
    		.Count() + 1;
    		
            Console.WriteLine(r);
        }
