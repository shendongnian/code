    var grouped = stations
    	.GroupBy(s => s.EstacionSensorEstacionNombre) //Get all stations grouped
    	.Select(g => new 
    	{ 
    		Station = g.Key,
    		DateAverages = g //All of the same named stations
    			.GroupBy(sub => sub.Fecha.Date) //Group those by date
    			.Select(subg => new 
    			{ 
    				subg.Key, 
    				Average = subg.Select(s => s.Valor).Average() 
    			})
    	});
