    // call ToList() to execute it on database and bring to memory.    
    var list = (from p in db.PublicHolidays
                select new {
                    Holiday = s.Holiday,
                    ReminderUnits = p.ReminderUnits
                    ReminderQuantity = p.ReminderQuantity
                }).ToList();
    // use it in memory
    var result = list.Select(x => new {
    		 		  Holiday = x.Holiday,
    		   	   	  ReminderDay = Convert.ToDateTime(x.Holiday).AddByUnit(x.ReminderUnits, -p.ReminderQuantity))
    			  }).ToList();
