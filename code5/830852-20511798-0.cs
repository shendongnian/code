    var database = Database.OpenNamedConnection("MyDbCnxString");
	var x= 11;					
	var y= 1;
	var result= database.Table1.FindAllByX(x)
                            .Select(
                                database.Table1.X,
                                database.Table1.Y
                            )
                        .Join(database.Table2)
                        .On(database.Table2.X== database.Table1.X)
                        .Where(database.Table2.Y== y);
	
	(result as object).Dump("Voila!");
