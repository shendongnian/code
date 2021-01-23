    var jsonData = new {
    	total = 1, //todo: calculate
    	page = 1,
    	records = db.TestModels.Count(),
    	rows = db.TestModels
    		.Select(x => new { x.Dataid, x.Name, x.Emailid })
    		.AsEnumerable()
    		.Select(x => new {
                id = x.DataId,
                cell = new string[3] { x.Dataid, x.Name, x.Emailid } 
            })
    		.ToArray();
    };
