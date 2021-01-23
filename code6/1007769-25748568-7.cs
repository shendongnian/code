    var list = new List<int> { 1, 2, 3 };
	while (list.MoveNext()) {
	 int x = list.Current; // x is always 1
	 while (list.MoveNext()) {
       int y = list.Current; // y becomes 2, then 3
	   Console.WriteLine("{0} {1}", x, y);
     }
    }
