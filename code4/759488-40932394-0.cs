    var db = new YourTableEntities();
    var dateNow = DateTime.Now; 
	db.YourTableEntities.Add(new YourTableEntities()
	{
		ColumnAInTable = someAVariable,
		ColumnBInTable = someBVariable,
		ColumnThatShouldDefaultToGetDate = dateNow
	});
