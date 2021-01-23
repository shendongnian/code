    var list=new List<string>();
	list.Add("2.2");
	list.Add("2.5");
	list.Add("2.2");
    // ...
	list.RemoveAll(item => item == "2.2");
