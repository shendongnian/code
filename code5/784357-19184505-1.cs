    var columnNames = new List<string>{"Foo", "Foo2"};
    var customerOrderCsvReader = new List<List<string>>{new List<string>{"Bar", "Bar2"}};
    
    
    var list = new List<dynamic>();
    foreach (var element in customerOrderCsvReader)
    {
    	var expando = new ExpandoObject();
    	var temp = (IDictionary<string, object>) expando;
    	int i = 0;
    	foreach(string columnName in columnNames)
    	{
    		temp[columnName] = element[i];
    		i++;
    	}
    	list.Add(expando);
    }
    
    //Print Bar
    Console.WriteLine (list[0].Foo);
    //Print Bar2
    Console.WriteLine (list[0].Foo2);
    
    //Print Bar
    Console.WriteLine ((list[0] as IDictionary<string, object>)["Foo"]);
    //Print Bar2
    Console.WriteLine ((list[0] as IDictionary<string, object>)["Foo2"]);
