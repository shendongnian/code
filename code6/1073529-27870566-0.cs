    List<DateTime> dates = new List<DateTime>(){
    		new DateTime(2015,1,1,0,0,1),
    		new DateTime(2015,1,1,0,1,1),
    		new DateTime(2015,1,2,0,2,2),
    		new DateTime(2015,1,2,0,3,3),
    		new DateTime(2015,1,3,0,4,4),
    		new DateTime(2015,1,3,0,5,5),
    		new DateTime(2015,1,9,8,7,6),
    		new DateTime(2015,1,9,9,7,7),
    		new DateTime(2015,1,9,10,8,8),
    		new DateTime(2015,1,9,11,9,9),
    		new DateTime(2015,1,9,12,10,10),
    		new DateTime(2015,1,9,13,11,11)
    		};
    		
    var qry = dates.Where(x=>x.ToString("yyyy/MM/dd")==new DateTime(2015,1,9).ToString("yyyy/MM/dd"));
    
    qry.Dump();
