    StreamWriter wtr = new StreamWriter("out.txt");
    var e = File.ReadLines(path).GetEnumerator();
    int lineno = 12; //arbitrary
    int counter = 0;
    string line = string.Empty;
    while(e.MoveNext())
    {
    	counter++;
    	if(counter == lineno)	
    		line = replaceLogic(e.Current);	
    	else
    		line = e.Current;
    	wtr.WriteLine(line);
    }
    wtr.Close();
