	var actions = new List<Action>();
	// this loop is "executed"
	for (int i = 0; i < 3; i++)
	{
    	actions.Add(() => Console.Write (i));
	}
	// pseudo "unroll" the loop
	// i = 0
	// action(0) = Console.WriteLine(i);
	// i = 1
	// action(1) = Console.WriteLine(i);
	// i = 2
	// action(2) = Console.WriteLine(i);
	// i = 3 => note the variable is "captured", so the current value is taken on executing
	foreach (Action a in actions)
	{
		a();
	}
	// pseudo "unroll" the foreach loop
	// a(0) = Console.WriteLine(3); <= last value of i
	// a(1) = Console.WriteLine(3); <= last value of i
	// a(2) = Console.WriteLine(3); <= last value of i
	// thus output is 333
	
	// fix
	var actions = new List<Action>();
	// this loop is "executed"
	for (int i = 0; i < 3; i++)
	{
		var temp = i;
    	actions.Add(() => Console.Write (temp));
	}
	// pseudo "unroll"
	// i = 0
	// temp = 0
	// actions(0) => Console.WriteLine(temp); >= temp = 0
	// i = 1
	// temp = 1
	// actions(1) => Console.WriteLine(temp); <= temp = 1
	// i = 2
	// temp = 2
	// actions(2) => Console.WriteLine(temp); <= temp = 2
	foreach (Action a in actions)
	{
		a();
	}
	// thus 012
