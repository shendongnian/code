    var collection = listA.Where(...).Take(...).Select(
        a => new B { ..., Position = pos++ });
    
    foreach(var item in collection)
    	Console.WriteLine(item.Position); //prints 0,1,2
    
    foreach(var item in collection)
    	Console.WriteLine(item.Position); //prints 3,4,5
