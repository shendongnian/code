    //Where condition is optional; ensures no blank lines are processed
    //to prevent index out of bounds error on Split
    var csvData = from row in File.ReadLines(@"path/to/csv/file").Where(arg => !string.IsNullOrWhiteSpace(arg) && arg.Length > 0).AsEnumerable()
        //Delimiter
	let column = row.Split(';')
	select new 
	{
		Prop1 = column[0],
		Prop2 = column[1],
		Prop3 = column[2],
		Prop4 = column[3],
		Prop5 = column[4]
	};
