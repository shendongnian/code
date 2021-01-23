	//create initial list
	List<string> myList = new List<string>{"Entry1","a","b","Entry2","c","d","e"};
	
	//remember previous group name
	string previousGroupName = null;
	//create grouped list
	var myGroupedList = 
		myList.Select(i => new{
			Value=i
			,GroupName=(i.StartsWith("Entry")?(previousGroupName = i):previousGroupName)
		})
		.GroupBy(gb => gb.GroupName);
	
    //output to LinqPad
	myGroupedList.Dump();
