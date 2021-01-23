	var dt = new DataTable();
	dt.Columns.Add("Price1", typeof(decimal));
	dt.Columns.Add("Price2", typeof(decimal));
	dt.Columns.Add("Price3", typeof(decimal));
	dt.Columns.Add("Price4", typeof(decimal));
	dt.Columns.Add("ColSum", typeof(decimal));
	
	dt.Rows.Add(new object[]{2.5, 4.6,8,99});
	dt.Rows.Add(new object[]{10,39,88.3,90});
	dt.Rows.Add(new object[]{99,21,33,3.2});
	
	
	dt.Columns["ColSum"].Expression = "Price1+Price2+Price3+Price4";
