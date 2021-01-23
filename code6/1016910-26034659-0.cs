    void Main()
    {
    
    	var LS_CLIENTHORRAIREs = new List<LS_CLIENTHORRAIRE>
    	{
    		new LS_CLIENTHORRAIRE{TheHour="09:00",HourMin=7,HourMAx=9},
    		new LS_CLIENTHORRAIRE{TheHour="12:00",HourMin=10,HourMAx=12},
    		new LS_CLIENTHORRAIRE{TheHour="15:00",HourMin=13,HourMAx=15},
    		new LS_CLIENTHORRAIRE{TheHour="18:00",HourMin=16,HourMAx=19}
    	};
    	LS_CLIENTHORRAIREs.Dump();
    	
    	int The_Hour = 10;
    
    	var query = from o in LS_CLIENTHORRAIREs 
                select new {o.TheHour,o.HourMin,o.HourMAx,selected = The_Hour >= o.HourMin && The_Hour <= o.HourMAx}
    			 ;
    	query.OrderBy (q => q.HourMAx>The_Hour ? 0 : 1).ThenBy (q => q.HourMAx).Dump();
    }
    public class LS_CLIENTHORRAIRE
    {
        public string TheHour{get;set;}
        public int HourMin{get;set;}
        public int HourMAx{get;set;}
    }
